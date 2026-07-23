using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MinesServer.Networking.Client.Packets.Actions;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct SuicidePacket() : IActionClientPacket<SuicidePacket>
{
    public byte PacketCode => ActionClientPacketCodeProvider.Cache<SuicidePacket>.Code;

    public int Size => Unsafe.SizeOf<SuicidePacket>();

    public int Encode(Span<byte> output) => output.UnsafeWrite(this);

    public static SuicidePacket Decode(ReadOnlySpan<byte> input) => input.UnsafeRead<SuicidePacket>();
}