using Chip8Compiler.Opcodes.Values;

namespace Chip8Compiler.Opcodes.Utils;

internal static class HexConvertExtensions
{
    public static string ToHex(this Value4Bit value4Bit) => value4Bit.Value.ToString("X")[0..1];
    public static string ToHex(this Value8Bit value8Bit) => value8Bit.Value.ToString("X")[0..2];
    public static string ToHex(this Value12Bit value12Bit) => value12Bit.Value.ToString("X")[0..3];
}