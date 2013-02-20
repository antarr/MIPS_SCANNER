namespace mips_syntax.utils
{
    public enum OperandType
    {
        Special,
        Temporary,
        Store,
        Pointer,
        ReturnAddress,
        OSReserved,
        Invalid,
        Constant,
        Memory,
        Label
    }
}