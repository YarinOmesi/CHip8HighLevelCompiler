using Chip8Compiler.Assembly.Parsing.Models;

namespace Chip8Compiler.Assembly.Parsing.Core;

public interface IAssemblyParser
{
    AssemblyProgram Parse(string code);
}