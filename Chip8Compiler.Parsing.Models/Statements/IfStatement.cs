using Chip8Compiler.Parsing.Models.Expressions;
using VisitorPatternGenerator.Attributes;

namespace Chip8Compiler.Parsing.Models.Statements;

[Visitable(nameof(Statement))]

public partial record IfStatement(Expression Condition, Block Body, Block? ElseBody) : Statement;