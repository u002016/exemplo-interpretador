namespace Interpreter
{
    public interface IIntepreterBase
    {
        void Execute(dynamic context, in dynamic result);
    }
}