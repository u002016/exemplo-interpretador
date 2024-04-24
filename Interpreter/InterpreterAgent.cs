using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Interpreter
{
    public class InterpreterAgent<TContext, TResult>
        where TResult : new()
    {
        private const string SMainSource = @"
                using System;
                
                namespace Interpreter
                {{
                    public class DynamicInterpreter : IIntepreterBase
                    {{
                        public void Execute(dynamic context, in dynamic result)
                        {{
                            {0}
                        }}
                    }}
                }}";

        private readonly Compilation _compilaton;

        private CompiledResult _compiledResult = null;

        private static string FormatSource(string source)
        {
            return string.Format(SMainSource, source);
        }
        private static Compilation Compile(string source)
        {
            var formattedSource = FormatSource(source);

            var syntaxTree = Microsoft.CodeAnalysis.CSharp.CSharpSyntaxTree.ParseText(formattedSource);

            List<MetadataReference> references = new();
            foreach (var r in ((string)AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES")).Split(Path.PathSeparator))
                references.Add(MetadataReference.CreateFromFile(r));

            return CSharpCompilation.Create($"{Guid.NewGuid().ToString("N")}.dll",
                 syntaxTrees: new[] { syntaxTree },
                 references: references,
                 options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
        }

        private CompiledResult GetCompiledResult()
        {
            if (this._compiledResult != null)
                return this._compiledResult;

            using (var ms = new MemoryStream())
            {
                EmitResult result = this._compilaton.Emit(ms);

                if (!result.Success)
                {
                    this._compiledResult = CompiledResult.CreateWithError(result);
                }
                else
                {
                    ms.Seek(0, SeekOrigin.Begin);
                    Assembly assembly = Assembly.Load(ms.ToArray());
                    Type type = assembly.GetType("Interpreter.DynamicInterpreter");

                    this._compiledResult = CompiledResult.Create(result, type);

                    //var obj = (IIntepreterBase)Activator.CreateInstance(type);
                }
            }
            return this._compiledResult;
        }

        public InterpreterAgent(string source)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentException($"'{nameof(source)}' cannot be null or whitespace.", nameof(source));
            }
            _compilaton = Compile(source);
        }
        public bool Validate(out IEnumerable<Message> messages)
        {
            var compiledResult = GetCompiledResult();
            messages = compiledResult.Messages;
            return compiledResult.IsSuccess;
        }

        public TResult Execute(TContext context)
        {
            if (TryExecute(context, out var result))
            {
                return result;
            }
            else
            {
                throw new CompilationException();
            }

        }

        public bool TryExecute(TContext context, out TResult result)
        {
            result = new TResult();
            dynamic dResult = result;
            var compiledResult = GetCompiledResult();
            if (compiledResult.IsSuccess)
            {
                IIntepreterBase intepreter = compiledResult.CreateInterpreter();
                intepreter.Execute(context, in dResult);
            }
            return compiledResult.IsSuccess;
        }
    }
}
