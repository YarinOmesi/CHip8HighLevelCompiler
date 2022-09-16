using Chip8Compiler.Opcodes.Utils;
using V4Bit = Chip8Compiler.Opcodes.Values.Value4Bit;
using V8Bit = Chip8Compiler.Opcodes.Values.Value8Bit;
using V12Bit = Chip8Compiler.Opcodes.Values.Value12Bit;

namespace Chip8Compiler.Opcodes;

public static class OpCodeFactory
{
    public static V4Bit RegisterToValue(Register register) => new V4Bit(Registers.GetValue(register));

    public static string OpCodeClearScreen() => "00E0";
    public static string OpCodeReturn() => "00EE";
    public static string OpCodeJump(V12Bit address) => $"1{address.ToHex()}";
    public static string OpCodeCall(V12Bit address) => $"1{address.ToHex()}";
    public static string OpCodeSkipIfEquals(V4Bit register, V8Bit value) => $"3{register.ToHex()}{value.ToHex()}";
    public static string OpCodeSkipIfNotEquals(V4Bit register, V8Bit value) => $"4{register.ToHex()}{value.ToHex()}";
    public static string OpCodeSkipIfRegistersEquals(V4Bit register1, V4Bit register2) => $"5{register1.ToHex()}{register2.ToHex()}0";
    public static string OpCodeSetRegister(V4Bit register, V8Bit value) => $"6{register.ToHex()}{value.ToHex()}";
    public static string OpCodeAddToRegister(V4Bit register, V8Bit value) => $"7{register.ToHex()}{value.ToHex()}";
    
    public static string OpCodeSetRegister(V4Bit destRegister, V4Bit srcRegister) => $"8{destRegister.ToHex()}{srcRegister.ToHex()}0";
    public static string OpCodeOrRegister(V4Bit destRegister, V4Bit register) => $"8{destRegister.ToHex()}{register.ToHex()}1";
    public static string OpCodeAndRegister(V4Bit destRegister, V4Bit register) => $"8{destRegister.ToHex()}{register.ToHex()}2";
    public static string OpCodeXorRegister(V4Bit destRegister, V4Bit register) => $"8{destRegister.ToHex()}{register.ToHex()}3";
    public static string OpCodeAddRegister(V4Bit destRegister, V4Bit register) => $"8{destRegister.ToHex()}{register.ToHex()}4";
    public static string OpCodeSubRegister(V4Bit destRegister, V4Bit register) => $"8{destRegister.ToHex()}{register.ToHex()}5";
    public static string OpCodeSiftRightRegister(V4Bit register1, V4Bit register2) => $"8{register1.ToHex()}{register2.ToHex()}6";
    public static string OpCodeOppositeSubRegister(V4Bit destRegister, V4Bit register) => $"8{destRegister.ToHex()}{register.ToHex()}7";
    public static string OpCodeShiftLeftRegister(V4Bit register1, V4Bit register2) => $"8{register1.ToHex()}{register2.ToHex()}E";

    public static string OpCodeSkipIfRegistersNotEquals(V4Bit register1, V4Bit register2) => $"9{register1.ToHex()}{register2.ToHex()}0";
    public static string OpCodeSetI(V12Bit address) => $"A{address.ToHex()}";
    public static string OpCodeJumpFromV0(V12Bit address) => $"B{address.ToHex()}";
    public static string OpCodeRandom(V4Bit register, V8Bit mask) => $"C{register.ToHex()}{mask.ToHex()}";
    public static string OpCodeDisplay(V4Bit registerRow,V4Bit registerCol, V4Bit size) => $"D{registerRow.ToHex()}{registerCol.ToHex()}{size.ToHex()}";
    
    public static string OpCodeSkipIfKeyInRegisterPressed(V4Bit register) => $"9{register.ToHex()}9E";
    public static string OpCodeSkipIfKeyInRegisterNotPressed(V4Bit register) => $"E{register.ToHex()}A1";
    public static string OpCodeStoreDelayTimer(V4Bit register) => $"F{register.ToHex()}07";
    public static string OpCodeWaitToKeyAndStore(V4Bit register) => $"F{register.ToHex()}0A";
    public static string OpCodeSetDelayTimer(V4Bit register) => $"F{register.ToHex()}15";
    public static string OpCodeSetSoundTimer(V4Bit register) => $"F{register.ToHex()}18";
    public static string OpCodeAddToI(V4Bit register) => $"F{register.ToHex()}1E";
    public static string OpCodeStoreAddressForDigitInI(V4Bit register) => $"F{register.ToHex()}29";
    public static string OpCodeStoreBcd(V4Bit register) => $"F{register.ToHex()}33";
    public static string OpCodeStoreRegistersInMemory(V4Bit register) => $"F{register.ToHex()}55";
    public static string OpCodeLoadRegistersFromMemory(V4Bit register) => $"F{register.ToHex()}65";
}