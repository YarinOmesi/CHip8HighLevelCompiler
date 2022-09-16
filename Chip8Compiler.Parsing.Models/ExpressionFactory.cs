using Chip8Compiler.Parsing.Models.Expressions;

namespace Chip8Compiler.Parsing.Models;

public static class ExpressionFactory
{
    public static HexNumber Hex(string hex) => new(new Token(hex, 0, 0));
    public static NumberExpression Number(string number) => new(new Token(number, 0, 0));
    public static VariableReferenceExpression Reference(Token name) => new(name);
}