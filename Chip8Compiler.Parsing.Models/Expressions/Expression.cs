using VisitorPatternGenerator.Attributes;

namespace Chip8Compiler.Parsing.Models.Expressions;

[Visitor]
public abstract record Expression
{
    public abstract T Accept<T>(IExpressionVisitor<T> visitor);
    public abstract void Accept(IExpressionVisitor visitor);
}