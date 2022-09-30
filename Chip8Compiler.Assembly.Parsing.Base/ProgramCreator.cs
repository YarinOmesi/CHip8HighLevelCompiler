using Chip8Compiler.Assembly.Parsing.Core;
using Chip8Compiler.Assembly.Parsing.Models;

namespace Chip8Compiler.Assembly.Parsing.Base.AntlrParser;

public class ProgramCreator : IProgramCreator
{
    private readonly IStatementCreator _statementCreator = new StatementCreator();

    public AssemblyProgram Create(Chip8AssemblyParser.ProgramContext context)
    {
        AssemblyStatement[] assemblyStatements = context.statement()
            .Select(statement => _statementCreator.Create(statement))
            .ToArray();

        return new AssemblyProgram(assemblyStatements);
    }
}