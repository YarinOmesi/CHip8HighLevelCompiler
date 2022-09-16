using Chip8Compiler.Parsing.Models.PrimitiveTypes;
using VisitorPatternGenerator.Attributes;

namespace Chip8Compiler.Parsing.Models.Expressions;

[Visitable(nameof(Expression))]
public partial record ArrayIndexerReferenceExpression(Token Name, Expression Index) : BaseExpressionReference(Name)
{
    public override VariablePrimitiveType ReferencePrimitiveType => VariablePrimitiveType.ByteArray;

}