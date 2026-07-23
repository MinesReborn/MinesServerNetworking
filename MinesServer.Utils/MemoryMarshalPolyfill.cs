using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MinesServer.Utils;

#if !NET7_0_OR_GREATER
public static class MemoryMarshalPolyfill
{
    public static ref T GetArrayDataReference<T>(T[] array)
    {
        return ref Unsafe.As<byte, T>(ref GetArrayDataReference((Array)array));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public unsafe static ref byte GetArrayDataReference(Array array)
    {
        return ref Unsafe.AddByteOffset(ref Unsafe.As<RawData>(array).Data, (UIntPtr)((MethodTable*)Unsafe.Add(ref Unsafe.As<byte, IntPtr>(ref Unsafe.As<RawData>(array).Data), -1))->BaseSize - 2 * sizeof(IntPtr));
    }

    internal sealed class RawData
    {
        public byte Data;
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct MethodTable
    {
        [FieldOffset(0)]
        public ushort ComponentSize;

        [FieldOffset(0)]
        private uint Flags;

        [FieldOffset(4)]
        public uint BaseSize;

        [FieldOffset(14)]
        public ushort InterfaceCount;

        [FieldOffset(16)]
        public unsafe MethodTable* ParentMethodTable;

        [FieldOffset(24)]
        public unsafe MethodTableAuxiliaryData* AuxiliaryData;

        [FieldOffset(32)]
        public unsafe void* ElementType;

        [FieldOffset(36)]
        public unsafe MethodTable** InterfaceMap;
    }
    [StructLayout(LayoutKind.Explicit)]
    internal struct MethodTableAuxiliaryData
    {
        [FieldOffset(0)]
        private uint Flags;
    }
}
#endif
