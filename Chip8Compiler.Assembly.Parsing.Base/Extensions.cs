using Antlr4.Runtime;
using Chip8Compiler.Assembly.Parsing.Models;

namespace Chip8Compiler.Assembly.Parsing.Base.AntlrParser;

//TODO: This is a duplicate
internal static class Extensions
{
    public static AssemblyToken ToToken(this IToken token)
    {
        return new AssemblyToken(token.Text, token.Line, token.Column);
    }
}