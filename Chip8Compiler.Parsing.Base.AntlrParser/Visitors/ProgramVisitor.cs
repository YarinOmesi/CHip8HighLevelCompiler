using Chip8Compiler.Parsing.Models;
using Chip8Compiler.Parsing.Models.Statements;

namespace Chip8Compiler.Parsing.Base.AntlrParser.Visitors;

internal class ProgramVisitor : Chip8BaseVisitor<Program>
{
    private readonly StatementsVisitor _statementsVisitor = new();

    public override Program VisitProgram(Chip8Parser.ProgramContext context)
    {
        Statement[] statements = context.declarationStatement()
            .Select(_statementsVisitor.VisitDeclarationStatement)
            .ToArray();

        MainMethodDeclarationStatement[] mains = statements.OfType<MainMethodDeclarationStatement>().ToArray();
        MethodDeclarationStatement[] methods = statements.OfType<MethodDeclarationStatement>().ToArray();

        return mains.Length switch {
            0 => throw new Exception("You Have to Define Main Method"),
            1 => new Program(mains[0], methods),
            _ => throw new Exception("You Can Define Only One Entry Point")
        };
    }
}