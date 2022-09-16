using Chip8Compiler.Parsing.Models;

namespace Chip8Compiler.Parsing.Core;

public interface IChip8Parser
{
    public Program? Parse(string code);
}