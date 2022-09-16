using VisitorPatternGenerator.Attributes;

namespace Chip8Compiler.Parsing.Models.Statements;


[Visitable(nameof(Statement))]
public partial record MainMethodDeclarationStatement(Token Name, Block Body) : Statement;