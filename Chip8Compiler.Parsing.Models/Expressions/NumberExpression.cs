using VisitorPatternGenerator.Attributes;

namespace Chip8Compiler.Parsing.Models.Expressions;


[Visitable(nameof(Expression))]
public partial record NumberExpression(Token Number) : Expression
{
    public override string ToString() => $"Number({Number.Text})";

}