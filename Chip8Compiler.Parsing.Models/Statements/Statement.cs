using VisitorPatternGenerator.Attributes;

namespace Chip8Compiler.Parsing.Models.Statements;

[Visitor]
public abstract record Statement
{
    public abstract T Accept<T>(IStatementVisitor<T> visitor);
    public abstract void Accept(IStatementVisitor visitor);
}