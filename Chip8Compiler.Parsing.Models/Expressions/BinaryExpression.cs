using VisitorPatternGenerator.Attributes;

namespace Chip8Compiler.Parsing.Models.Expressions;


[Visitable(nameof(Expression))]
public partial record BinaryExpression(BinaryKind Kind, Expression Left, Token Operator, Expression Right) : Expression
{
    public override string ToString()
    {
        return $"{Left} '{Operator.Text}' {Right}";
    }
}

