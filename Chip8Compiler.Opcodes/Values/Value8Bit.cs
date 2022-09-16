using Chip8Compiler.Opcodes.Utils;

namespace Chip8Compiler.Opcodes.Values;

public class Value8Bit
{
    public int Value { get; }

    public Value8Bit(int value)
    {
        value.ThrowIfNotInRange(0, 0xFF);
        Value = value;
    }
}