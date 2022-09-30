using Antlr4.Runtime;
using Chip8Compiler.Assembly.Parsing.Core;
using Chip8Compiler.Assembly.Parsing.Models;

namespace Chip8Compiler.Assembly.Parsing.Base.AntlrParser;

public class AssemblyAntlrParser : IAssemblyParser
{
    private readonly IProgramCreator _programCreator;

    public AssemblyAntlrParser()
    {
        var parameterCreator = new ParameterCreator();
        var statementCreator = new StatementCreator(parameterCreator);
        _programCreator = new ProgramCreator(statementCreator);
    }

    public AssemblyProgram Parse(string code)
    {
        var inputStream = new AntlrInputStream(code);
        var lexer = new Chip8AssemblyLexer(inputStream);
        var commonTokenStream = new CommonTokenStream(lexer);
        var parser = new Chip8AssemblyParser(commonTokenStream);
        AssemblyProgram program = _programCreator.Create(parser.program());
        return program;
    }
}