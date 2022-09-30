using Chip8Compiler.Parsing.Models.Expressions;
using VisitorPatternGenerator.Attributes;

namespace Chip8Compiler.Parsing.Models.Statements;


[Visitable(nameof(Statement))]
public partial record VariableDeclarationStatement(Token Name, Expression? Value) : Statement;