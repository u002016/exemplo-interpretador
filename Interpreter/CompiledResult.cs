using Microsoft.CodeAnalysis.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    internal class CompiledResult
    {
        public Type CompiledType { get; }
        public  bool IsSuccess { get; }
        public  IEnumerable<Message> Messages { get; }

        private CompiledResult(Type compiledType, bool isSuccess, IEnumerable<Message> messages)
        {
            this.CompiledType = compiledType;
            this.IsSuccess = isSuccess;
            this.Messages = messages;
        }

        private static IEnumerable<Message> GetMessages(EmitResult emitResult)
        {
            return emitResult.Diagnostics.Select(dr => new Message()
            {
                Kind = dr.DefaultSeverity.ToMessageKind(),
                Text = $"({dr.Location.GetLineSpan().StartLinePosition.Line}) {dr.Id}: {dr.GetMessage()}"
            }).ToArray();
        }        

        public static CompiledResult CreateWithError(EmitResult emitResult)
        {
            return Create(emitResult, null);
        }

        internal static CompiledResult Create(EmitResult emitResult, Type type)
        {
            var messages = GetMessages(emitResult);
            return new CompiledResult(type, emitResult.Success, messages);

        }

        internal IIntepreterBase CreateInterpreter()
        {
            return (IIntepreterBase)Activator.CreateInstance(this.CompiledType);
        }
    }
}
