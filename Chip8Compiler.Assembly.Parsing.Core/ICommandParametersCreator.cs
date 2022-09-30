using Chip8Compiler.Assembly.Parsing.Models;

namespace Chip8Compiler.Assembly.Parsing.Core;

public interface ICommandParametersCreator
{
    public CommandParameter[] Create(Chip8AssemblyParser.CommandParamsContext context);
}