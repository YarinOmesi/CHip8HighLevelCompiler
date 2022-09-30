using Chip8Compiler.Assembly.Parsing.Models;

namespace Chip8Compiler.Assembly.Parsing.Core;

public interface IProgramCreator
{
    public AssemblyProgram Create(Chip8AssemblyParser.ProgramContext context);
}