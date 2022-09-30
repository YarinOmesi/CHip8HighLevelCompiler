using Chip8Compiler.Assembly.Parsing.Models;

namespace Chip8Compiler.Assembly.Parsing.Base.AntlrParser;

public interface IStatementCreator
{
    public AssemblyStatement Create(Chip8AssemblyParser.StatementContext context);
}