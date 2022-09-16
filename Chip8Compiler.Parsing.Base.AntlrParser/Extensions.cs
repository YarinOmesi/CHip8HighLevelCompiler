using Antlr4.Runtime;
using Chip8Compiler.Parsing.Models;
using Chip8Compiler.Parsing.Models.Expressions;

namespace Chip8Compiler.Parsing.Base.AntlrParser;

internal static class Extensions
{
    public static Token ToToken(this IToken token) => new(token.Text, token.Line, token.Column);

    public static BinaryExpression Create(this BinaryKind kind, Expression left, Token op, Expression  right) =>
        new(kind, left, op, right);
    
}