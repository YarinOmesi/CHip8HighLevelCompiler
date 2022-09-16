using System.Text;
using VisitorPatternGenerator.Attributes;

namespace Chip8Compiler.Parsing.Models.Expressions;

public record BinaryRightSide(Token Operator, Expression Right);

[Visitable(nameof(Expression))]
public partial record MultipleSideBinaryExpression(MultiBinaryKind Kind, Expression Left, BinaryRightSide[] Right) : Expression
{
    protected override bool PrintMembers(StringBuilder builder)
    {
        builder.Append(nameof(Kind)).Append(" = ").Append(Kind).Append(", ");
        builder.Append(nameof(Left)).Append(" = ").Append(Left).Append(", ");
        builder.Append(nameof(Right)).Append(" = ").Append('[');
        foreach (BinaryRightSide binaryRightSide in Right)
        {
            builder.Append("{ ").Append(binaryRightSide.Operator.Text).Append(' ').Append(binaryRightSide.Right)
                .Append(" }, ");
        }
        builder.Append(']');
        return true;
    }
}