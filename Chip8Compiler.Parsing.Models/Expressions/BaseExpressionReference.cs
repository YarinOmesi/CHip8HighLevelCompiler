
using Chip8Compiler.Parsing.Models.PrimitiveTypes;

namespace Chip8Compiler.Parsing.Models.Expressions;

public abstract record BaseExpressionReference(Token Name) : Expression
{
    public abstract VariablePrimitiveType ReferencePrimitiveType { get; }
}