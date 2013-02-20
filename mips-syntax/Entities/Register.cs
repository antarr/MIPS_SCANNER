using mips_syntax.utils;

namespace mips_syntax.Entities
{
    public enum Register
    {
        Zero = OperandType.Special,
        T0 = OperandType.Temporary,
        T1 = OperandType.Temporary,
        T2 = OperandType.Temporary,
        T3 = OperandType.Temporary,
        T4 = OperandType.Temporary,
        T5 = OperandType.Temporary,
        T6 = OperandType.Temporary,
        T7 = OperandType.Temporary,
        T8 = OperandType.Temporary,
        T9 = OperandType.Temporary,
        S0 = OperandType.Store,
        S1 = OperandType.Store,
        S2 = OperandType.Store,
        S3 = OperandType.Store,
        S4 = OperandType.Store,
        S5 = OperandType.Store,
        S6 = OperandType.Store,
        S7 = OperandType.Store,
        S8 = OperandType.Store,
        Gp = OperandType.Pointer,
        Fp = OperandType.Pointer,
        Sp = OperandType.Pointer,
        Ra = OperandType.ReturnAddress,
        K0 = OperandType.OSReserved,
        K1 = OperandType.OSReserved,
        Invalid =OperandType.Invalid
    }
}