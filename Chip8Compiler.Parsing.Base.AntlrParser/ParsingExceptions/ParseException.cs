using System.Runtime.Serialization;

namespace Chip8Compiler.Parsing.Base.AntlrParser.ParsingExceptions;

public abstract class ParseException:Exception
{
    protected ParseException()
    {
    }

    protected ParseException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    protected ParseException(string? message) : base(message)
    {
    }

    protected ParseException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}