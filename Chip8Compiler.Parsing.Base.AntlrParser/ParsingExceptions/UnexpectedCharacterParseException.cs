using System.Runtime.Serialization;

namespace Chip8Compiler.Parsing.Base.AntlrParser.ParsingExceptions;

public class UnexpectedCharacterParseException : ParseException
{
    public int Line { get; }
    public int CharPositionInLine { get; }
    public string Text { get; }

    public UnexpectedCharacterParseException(int line, int charPositionInLine, string text)
    {
        Line = line;
        this.CharPositionInLine = charPositionInLine;
        Text = text;
    }

    protected UnexpectedCharacterParseException(SerializationInfo info, StreamingContext context, int line, int charPositionInLine, string text) : base(info, context)
    {
        Line = line;
        this.CharPositionInLine = charPositionInLine;
        Text = text;
    }

    public UnexpectedCharacterParseException(string? message, int line, int charPositionInLine, string text) : base(message)
    {
        Line = line;
        this.CharPositionInLine = charPositionInLine;
        Text = text;
    }

    public UnexpectedCharacterParseException(string? message, Exception? innerException, int line, int charPositionInLine, string text) : base(message, innerException)
    {
        Line = line;
        this.CharPositionInLine = charPositionInLine;
        Text = text;
    }
}