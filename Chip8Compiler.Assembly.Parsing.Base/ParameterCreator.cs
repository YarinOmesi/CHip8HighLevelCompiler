using Chip8Compiler.Assembly.Parsing.Models;

namespace Chip8Compiler.Assembly.Parsing.Base.AntlrParser;

internal class ParameterCreator : ICommandParametersCreator
{
    private readonly Visitor _visitor = new Visitor();

    public CommandParameter[] Create(Chip8AssemblyParser.CommandParamsContext context)
    {
        _visitor.Parameters = new List<CommandParameter>();
        _visitor.VisitCommandParams(context);
        return _visitor.Parameters.ToArray();
    }

    private class Visitor : Chip8AssemblyBaseVisitor<object?>
    {
        public List<CommandParameter> Parameters { get; set; } = new(0);

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
}