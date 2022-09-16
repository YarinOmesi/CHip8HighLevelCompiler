using Antlr4.Runtime.Tree;
using Chip8Compiler.Parsing.Models.Expressions;

namespace Chip8Compiler.Parsing.Base.AntlrParser.Visitors;

internal class ExpressionVisitor : Chip8BaseVisitor<Expression>
{
    public override Expression VisitStatement(Chip8Parser.StatementContext context)
    {
        throw new Exception("Cant Visit Statement");
    }
    
    public override Expression VisitEquality(Chip8Parser.EqualityContext context)
    {
        return context.EQUALITY_OPS() is null
            ? Visit(context.left)
            : BinaryKind.Equality.Create(Visit(context.left), context.EQUALITY_OPS().Symbol.ToToken(), Visit(context.right));
    }

    public override Expression VisitComparision(Chip8Parser.ComparisionContext context)
    {
        return context.COMPARISION_OPS() is null
            ? Visit(context.left)
            : BinaryKind.Comparison.Create(Visit(context.left), context.COMPARISION_OPS().Symbol.ToToken(), Visit(context.right));
    }

    public override Expression VisitTerm(Chip8Parser.TermContext context)
    {
        Expression left = VisitFactor(context.left);
        List<BinaryRightSide> rightSides = new();
        foreach ((ITerminalNode op, Chip8Parser.FactorContext factorContext) in context.TERM_OPS().Zip(context.factor().Skip(1)))
        {
            Expression right = VisitFactor(factorContext);
            rightSides.Add(new BinaryRightSide(op.Symbol.ToToken(), right));
        }
        
        return rightSides.Count == 0 ? left : new MultipleSideBinaryExpression(MultiBinaryKind.Term, left, rightSides.ToArray());
    }
    
    public override Expression VisitFactor(Chip8Parser.FactorContext context)
    {
        Expression left = VisitPrimary(context.left);
        List<BinaryRightSide> rightSides = new();
        foreach ((ITerminalNode op, Chip8Parser.PrimaryContext primaryContext) in context.FACTOR_OPS().Zip(context.primary().Skip(1)))
        {
            Expression right = VisitPrimary(primaryContext);
            rightSides.Add(new BinaryRightSide(op.Symbol.ToToken(), right));
        }
        
        return rightSides.Count == 0 ? left : new MultipleSideBinaryExpression(MultiBinaryKind.Factor, left, rightSides.ToArray());
    }

    public override Expression VisitReferenceIdentifier(Chip8Parser.ReferenceIdentifierContext context)
    {
        return new VariableReferenceExpression(context.IDENTIFIER().Symbol.ToToken());
    }

    public override Expression VisitArrayIndexer(Chip8Parser.ArrayIndexerContext context)
    {
        return new ArrayIndexerReferenceExpression(context.IDENTIFIER().Symbol.ToToken(),
            Visit(context.expression()));
    }
    
    public override Expression VisitGrouping(Chip8Parser.GroupingContext context)
    {
        return new GroupingExpression(Visit(context.expression()));
    }

    public override Expression VisitNumber(Chip8Parser.NumberContext context)
    {
        var number = context.NUMBER().Symbol.ToToken();
        bool isHex = number.Text.StartsWith("0x");
        return isHex? new HexNumber(number): new NumberExpression(number);
    }

    public override Expression VisitArraySyntax(Chip8Parser.ArraySyntaxContext context)
    {
        return new ArraySyntaxExpression(ArrayItems(context.arraySyntaxItems()));
    }

    private Expression[] ArrayItems(Chip8Parser.ArraySyntaxItemsContext context)
    {
        var values = new List<Expression>();
        while (context!= null)
        {
            if (context.term()!=null)
            {
                values.Add(Visit(context.term()));
            }
            context = context.arraySyntaxItems();
        }
        return values.ToArray();
    }
}