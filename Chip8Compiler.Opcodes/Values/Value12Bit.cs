using Chip8Compiler.Opcodes.Utils;

namespace Chip8Compiler.Opcodes.Values;

public class Value12Bit
{
    public int Value { get; }

    public Value12Bit(int value)
    {
        value.ThrowIfNotInRange(0, 0xFFF);
        Value = value;
    }
}