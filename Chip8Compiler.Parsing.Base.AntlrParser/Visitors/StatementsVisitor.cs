using Chip8Compiler.Parsing.Models;
using Chip8Compiler.Parsing.Models.Expressions;
using Chip8Compiler.Parsing.Models.Statements;

namespace Chip8Compiler.Parsing.Base.AntlrParser.Visitors;

internal class StatementsVisitor : Chip8BaseVisitor<Statement>
{
    private readonly ExpressionVisitor _expressionVisitor = new();

    public override Statement VisitExpression(Chip8Parser.ExpressionContext context)
    {
        throw new Exception("Cant Visit Expression");
    }

    public override Statement VisitMethodDeclStatement(Chip8Parser.MethodDeclStatementContext context)
    {
        Block body = Block(context.block());
        return new MethodDeclarationStatement(context.name.ToToken(), Parameters(context.parameters()), body);
    }

    private Token[] Parameters(Chip8Parser.ParametersContext context)
    {
        var typedNames = new List<Token>();
        while (context != null)
        {
            if (context.typeAndName() != null)
            {
                typedNames.Add(context.typeAndName().name.ToToken());
            }

            context = context.parameters();
        }

        return typedNames.ToArray();
    }
    
    private Block Block(Chip8Parser.BlockContext blockContext)
    {
        return new Block(blockContext.statementsInMethod().Select(VisitStatementsInMethod).ToArray());
    }

    public override Statement VisitMainDecl(Chip8Parser.MainDeclContext context)
    {
        Statement[] statements = context.statement().Select(VisitStatement).ToArray();
        return new MainMethodDeclarationStatement(context.name.ToToken(), new Block(statements));
    }

    public override Statement VisitReturnStatement(Chip8Parser.ReturnStatementContext context)
    {
        return new ReturnStatement(context.token.ToToken());
    }

    public override Statement VisitCallStetemnt(Chip8Parser.CallStetemntContext context)
    {
        return new CallSubroutineStatement(context.name.ToToken(), Arguments(context.arguments()));
    }

    private Expression[] Arguments(Chip8Parser.ArgumentsContext context)
    {
        var arguments = new List<Expression>();
        while (context != null)
        {
            if (context.expression() != null)
            {
                arguments.Add(_expressionVisitor.Visit(context.expression()));
            }
            context = context.arguments();
        }
        return arguments.ToArray();
    }

    public override Statement VisitVariableDeclarationStatement(Chip8Parser.VariableDeclarationStatementContext context)
    {
        return new VariableDeclarationStatement(
            context.typeAndName().name.ToToken(), _expressionVisitor.Visit(context.value) 
        );
    }

    public override Statement VisitAssignmentStatement(Chip8Parser.AssignmentStatementContext context)
    {
        return new AssignmentStatement((VariableReferenceExpression) _expressionVisitor.VisitReference(context.reference()),
            _expressionVisitor.Visit(context.value));
    }

    public override Statement VisitIfStatement(Chip8Parser.IfStatementContext context)
    {
        return new IfStatement(
            _expressionVisitor.Visit(context.expression()),
            Block(context.body),
            context.elseBlock != null ? Block(context.elseBlock) : null
        );
    }

    public override Statement VisitWhileStatement(Chip8Parser.WhileStatementContext context)
    {
        return new WhileStatement(_expressionVisitor.Visit(context.expression()), Block(context.block()));
    }
}