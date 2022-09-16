using VisitorPatternGenerator.Attributes;

namespace Chip8Compiler.Parsing.Models.Statements;

[Visitable(nameof(Statement))]
public partial record MethodDeclarationStatement(Token Name, TypedName[] Parameters, Block Body) : Statement;