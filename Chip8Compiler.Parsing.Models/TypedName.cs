using Chip8Compiler.Parsing.Models.PrimitiveTypes;

namespace Chip8Compiler.Parsing.Models;

public record TypedName(PrimitiveType Type, Token Name);