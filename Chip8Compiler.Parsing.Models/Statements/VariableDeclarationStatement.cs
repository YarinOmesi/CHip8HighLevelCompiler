using Chip8Compiler.Parsing.Models.Expressions;
using Chip8Compiler.Parsing.Models.PrimitiveTypes;
using VisitorPatternGenerator.Attributes;

namespace Chip8Compiler.Parsing.Models.Statements;


[Visitable(nameof(Statement))]
public partial record VariableDeclarationStatement(PrimitiveType Type, Token Name, Expression Value) : Statement
{
    public VariableDeclarationStatement(TypedName typedName, Expression value) :
        this(typedName.Type, typedName.Name, value)
    {
    }

}