using MinesServer.Utils;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MinesServer.Networking;

internal static class PacketExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Write(this ref MemoryWriter writer, INetworkPacketBase packet)
        => writer.Advance(packet.Encode(writer.Remaining));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int UnsafeWrite<T>(this Span<byte> output, T packet) where T : struct, INetworkPacketBase
    {
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(output), packet);
        return Unsafe.SizeOf<T>();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T UnsafeRead<T>(this ReadOnlySpan<byte> input) where T : struct, INetworkPacket<T>
        => Unsafe.ReadUnaligned<T>(ref MemoryMarshal.GetReference(input));
}