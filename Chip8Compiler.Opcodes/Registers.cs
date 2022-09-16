namespace Chip8Compiler.Opcodes;

public static class Registers
{
    public static readonly Register[] All = {
       Register.V0,
       Register.V1,
       Register.V2,
       Register.V3,
       Register.V4,
       Register.V5,
       Register.V6,
       Register.V7,
       Register.V8,
       Register.V9,
       Register.VA,
       Register.VB,
       Register.VC,
       Register.VD,
       Register.VE,
       Register.VF
    };

    public static readonly int Count = All.Length;

    public static int GetValue(Register register)
    {
        for (var i = 0; i < All.Length; i++)
        {
            if (register == All[i])
                return i;
        }

        throw new Exception("Not Found");
    }
    
    
}