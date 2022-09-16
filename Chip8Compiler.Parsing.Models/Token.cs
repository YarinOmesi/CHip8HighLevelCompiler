namespace Chip8Compiler.Parsing.Models;

public record Token(string Text, int Line, int Col)
{
    public override string ToString()
    {
        return Text;
    }

    public bool TextEquals(Token o) => Text == o.Text;
}