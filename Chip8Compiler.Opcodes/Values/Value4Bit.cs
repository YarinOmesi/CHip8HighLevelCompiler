using Chip8Compiler.Opcodes.Utils;

namespace Chip8Compiler.Opcodes.Values;

public class Value4Bit
{
    public int Value { get; }

    public Value4Bit(int value)
    {
        value.ThrowIfNotInRange(0, 0xF);
        Value = value;
    }
};