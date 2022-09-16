using Chip8Compiler.Parsing.Models.PrimitiveTypes;

namespace Chip8Compiler.Parsing.Models;

public static class TypesFactory
{
    public static PrimitiveType ByteType() => new(new Token("byte", 0, 0), VariablePrimitiveType.Byte);
}