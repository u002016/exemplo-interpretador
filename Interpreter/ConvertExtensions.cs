using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    internal static class ConvertExtensions
    {
        public static MessageKind ToMessageKind (this DiagnosticSeverity diagnosticSeverity)
        {
            switch (diagnosticSeverity)
            {
                case DiagnosticSeverity.Hidden:
                case DiagnosticSeverity.Info:
                    return MessageKind.Info;
                case DiagnosticSeverity.Warning:
                    return MessageKind.Warning;
                case DiagnosticSeverity.Error:
                    return MessageKind.Error;
                default:
                    throw new ArgumentOutOfRangeException($"Invalid value for {nameof(DiagnosticSeverity)}: {diagnosticSeverity}"); ;
            }
        }
    }
}
