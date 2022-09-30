using Chip8Compiler.Assembly.Parsing.Models;

namespace Chip8Compiler.Assembly.Parsing.Base.AntlrParser;

internal class StatementCreator : IStatementCreator
{
    private readonly Visitor _visitor;

    public StatementCreator()
    {
        ICommandParametersCreator parametersCreator = new ParameterCreator();
        _visitor = new Visitor(parametersCreator);
    }

    public AssemblyStatement Create(Chip8AssemblyParser.StatementContext context)
    {
        return _visitor.VisitStatement(context);
    }

    private class Visitor : Chip8AssemblyBaseVisitor<AssemblyStatement>
    {
        private readonly ICommandParametersCreator _parametersCreator;

        public Visitor(ICommandParametersCreator parametersCreator)
        {
            _parametersCreator = parametersCreator;
        }

        public override AssemblyStatement VisitCommand(Chip8AssemblyParser.CommandContext context)
        {
            return new CommandStatement(context.COMMAND_NAME().Symbol.ToToken(),
                _parametersCreator.Create(context.commandParams()));
        }

        public override AssemblyStatement VisitLabel(Chip8AssemblyParser.LabelContext context)
        {
            return new LabelStatement(context.LABEL().Symbol.ToToken());
        }
    }
}