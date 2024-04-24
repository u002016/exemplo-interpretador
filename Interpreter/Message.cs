using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    public sealed class Message
    {
        public string Text { get; init; }
        public MessageKind Kind { get; init; }
    }
}
