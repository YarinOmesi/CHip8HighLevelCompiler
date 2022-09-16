using System.Runtime.CompilerServices;

namespace Chip8Compiler.Opcodes.Utils;

internal static class ArgumentOutOfRange
{
    public static void ThrowIfNotInRange<T>(this T value, T minInclusive, T maxExclusive,
        [CallerArgumentExpression("value")] string expression = "") where T : IComparable<T>
    {
        if (value.CompareTo(minInclusive) < 0 || value.CompareTo(maxExclusive) > 0)
        {
            throw new ArgumentOutOfRangeException(expression,
                $"{expression} Should Be Bigger Or Equal To {minInclusive} And Less Than {maxExclusive}");
        }
    }
}