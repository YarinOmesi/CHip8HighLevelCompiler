using VisitorPatternGenerator.Attributes;

namespace Chip8Compiler.Parsing.Models.Expressions;

[Visitable(nameof(Expression))]
public partial record HexNumber(Token Hex) : Expression
{
    public override string ToString() => $"Hex({Hex.Text})";
}