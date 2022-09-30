using Chip8Compiler.Assembly.Antlr;
using Chip8Compiler.Assembly.Parsing.Core;
using Chip8Compiler.Assembly.Parsing.Models;

namespace Chip8Compiler.Assembly.Parsing.Base.AntlrParser;

public class StatementVisitor : Chip8AssemblyBaseVisitor<AssemblyStatement>,IStatementCreator
{
    public List<AssemblyStatement> Statements { get; } = new();
    
    private readonly ICommandParametersCreator _parametersCreator = new ParameterVisitor();

    public AssemblyStatement Create(Chip8AssemblyParser.StatementContext context)
    {
        return VisitStatement(context);
    }

    public override AssemblyStatement VisitStatement(Chip8AssemblyParser.StatementContext context)
    {
        AssemblyStatement assemblyStatement = base.VisitStatement(context);
        Statements.Add(assemblyStatement);
        return assemblyStatement;
    }

    public override AssemblyStatement VisitCommand(Chip8AssemblyParser.CommandContext context)
    {
        return new CommandStatement(context.COMMAND_NAME().Symbol.ToToken(), _parametersCreator.Create(context.commandParams()));
    }


    public override AssemblyStatement VisitLabel(Chip8AssemblyParser.LabelContext context)
    {
        return new LabelStatement(context.LABEL().Symbol.ToToken());
    }
}