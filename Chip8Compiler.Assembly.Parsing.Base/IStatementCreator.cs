using Chip8Compiler.Assembly.Parsing.Models;

namespace Chip8Compiler.Assembly.Parsing.Base.AntlrParser;

internal interface IStatementCreator
{
    public AssemblyStatement Create(Chip8AssemblyParser.StatementContext context);
}