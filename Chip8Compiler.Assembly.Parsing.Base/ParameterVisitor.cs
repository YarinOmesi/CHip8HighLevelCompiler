using Chip8Compiler.Assembly.Parsing.Core;
using Chip8Compiler.Assembly.Parsing.Models;

namespace Chip8Compiler.Assembly.Parsing.Base.AntlrParser;

public class ParameterVisitor : Chip8AssemblyBaseVisitor<object?>, ICommandParametersCreator
{
    public List<CommandParameter> Parameters { get; private set; } = new(0);

    public CommandParameter[] Create(Chip8AssemblyParser.CommandParamsContext context)
    {
        Parameters = new List<CommandParameter>();
        VisitCommandParams(context);
        return Parameters.ToArray();
    }

    public override object? VisitVariableParam(Chip8AssemblyParser.VariableParamContext context)
    {
        Parameters.Add(new CommandParameter(context.IDENTIFIER().Symbol.ToToken(), ParameterType.Variable));
        return null;
    }

    public override object? VisitValueParam(Chip8AssemblyParser.ValueParamContext context)
    {
        Parameters.Add(new CommandParameter(context.NUMBER().Symbol.ToToken(), ParameterType.Value));
        return null;
    }

    public override object? VisitLabelParam(Chip8AssemblyParser.LabelParamContext context)
    {
        Parameters.Add(new CommandParameter(context.LABEL().Symbol.ToToken(), ParameterType.Label));
        return null;
    }
}