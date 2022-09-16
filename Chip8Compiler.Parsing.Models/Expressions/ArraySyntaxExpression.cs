using VisitorPatternGenerator.Attributes;

namespace Chip8Compiler.Parsing.Models.Expressions;
[Visitable(nameof(Expression))]
public partial record ArraySyntaxExpression(Expression[] Values) : Expression;