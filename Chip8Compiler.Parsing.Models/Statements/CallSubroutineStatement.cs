using Chip8Compiler.Parsing.Models.Expressions;
using VisitorPatternGenerator.Attributes;

namespace Chip8Compiler.Parsing.Models.Statements;

[Visitable(nameof(Statement))]
public partial record CallSubroutineStatement(Token Name, Expression[] Arguments) : Statement;