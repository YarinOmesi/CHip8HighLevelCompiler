using Chip8Compiler.Parsing.Models.PrimitiveTypes;

namespace Chip8Compiler.Parsing.Base.AntlrParser.Visitors;

public class TypeVisitor : Chip8BaseVisitor<PrimitiveType>
{
    public override PrimitiveType VisitArrayType(Chip8Parser.ArrayTypeContext context)
    {
        return new PrimitiveType(context.token.ToToken(), VariablePrimitiveType.ByteArray);
    }

    public override PrimitiveType VisitByteType(Chip8Parser.ByteTypeContext context)
    {
        return new PrimitiveType(context.token.ToToken(), VariablePrimitiveType.Byte);
    }
}