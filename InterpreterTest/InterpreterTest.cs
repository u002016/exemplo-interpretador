using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Interpreter;
using System.Linq;

namespace InterpreterTest
{
    [TestClass]
    public partial class InterpreterTest
    {
        private string SFormulaCalculaDataNascimento = @"
            var dataAtual = new DateTime(2021, 06, 15);
            var ts = dataAtual - context.DataNascimento;
            result.Idade = ts.Days / 365;";

        private string SFormulaCalculaDataNascimentoErroCompilacao = @"
           var ts = dataAtual - context.DataNascimento
            result.Idade = ts.Days / 365;";

        private static ContextoExemplo CreateContext()
        {
            return new ContextoExemplo()
            {
                DataNascimento = new DateTime(1973, 2, 15),
                Nome = "Emerson"
            };
        }

        [TestMethod]
        public void Validate_Sucess()
        {
            #region Arrange
            var agent = new InterpreterAgent<ContextoExemplo, ResultadoExemplo>(SFormulaCalculaDataNascimento);
            #endregion

            #region Act
            bool ok = agent.Validate(out var messages);
            #endregion

            #region Assert
            Assert.IsTrue(ok && !messages.Any(m => m.Kind == MessageKind.Error));

            #endregion
        }

        [TestMethod]
        public void Validate_CompilationError()
        {
            #region Arrange
            var agent = new InterpreterAgent<ContextoExemplo, ResultadoExemplo>(SFormulaCalculaDataNascimentoErroCompilacao);
            #endregion

            #region Act
            bool ok = agent.Validate(out var messages);
            #endregion

            #region Assert
            Assert.IsTrue(!ok && messages.Any(m => m.Kind == MessageKind.Error));
            #endregion
        }

        [TestMethod]
        public void Execute_Sucess()
        {
            #region Arrange
            var contexto = CreateContext();
            var agent = new InterpreterAgent<ContextoExemplo, ResultadoExemplo>(SFormulaCalculaDataNascimento);
            #endregion

            #region Act
            var result = agent.Execute(contexto);
            #endregion

            #region Assert
            Assert.IsTrue(result.Idade == 48);
            #endregion
        }

        [TestMethod]
        public void Execute_CompilationError()
        {
            #region Arrange
            var contexto = CreateContext();
            var agent = new InterpreterAgent<ContextoExemplo, ResultadoExemplo>(SFormulaCalculaDataNascimento);
            #endregion

            #region Act
            try
            {
                agent.Execute(contexto);
            }
            #endregion
            #region Assert
            catch (CompilationException)
            {
                Assert.IsTrue(true);
            }
            #endregion
        }

        [TestMethod]
        public void TryExecute_Sucess()
        {
            #region Arrange
            var contexto = CreateContext();
            var agent = new InterpreterAgent<ContextoExemplo, ResultadoExemplo>(SFormulaCalculaDataNascimento);
            #endregion

            #region Act
            var ok = agent.TryExecute(contexto, out var result);
            #endregion

            #region Assert
            Assert.IsTrue(ok && result.Idade == 48);
            #endregion
        }

        [TestMethod]
        public void TryExecute_CompilationError()
        {
            #region Arrange
            var contexto = CreateContext();
            var agent = new InterpreterAgent<ContextoExemplo, ResultadoExemplo>(SFormulaCalculaDataNascimentoErroCompilacao);
            #endregion

            #region Act
            var ok = agent.TryExecute(contexto, out var _);
            #endregion
            #region Assert
            Assert.IsFalse(ok);
            #endregion
        }
    }
}
