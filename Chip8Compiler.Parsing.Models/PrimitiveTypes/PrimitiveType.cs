namespace Chip8Compiler.Parsing.Models.PrimitiveTypes;

public record PrimitiveType(Token Name, VariablePrimitiveType Type)
{
    public bool IsSameType(PrimitiveType other) => Type == other.Type;

    public override string ToString()
    {
        return $"Primitive({Name.Text})";
    }
}