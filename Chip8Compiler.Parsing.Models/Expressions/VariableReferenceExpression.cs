using Chip8Compiler.Parsing.Models.PrimitiveTypes;
using VisitorPatternGenerator.Attributes;

namespace Chip8Compiler.Parsing.Models.Expressions;

[Visitable(nameof(Expression))]
public partial record VariableReferenceExpression(Token Name) : BaseExpressionReference(Name)
{
    public override VariablePrimitiveType ReferencePrimitiveType => VariablePrimitiveType.Byte;

}