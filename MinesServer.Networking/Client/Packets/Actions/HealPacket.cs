using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MinesServer.Networking.Client.Packets.Actions;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct HealPacket() : IActionClientPacket<HealPacket>
{
    public byte PacketCode => ActionClientPacketCodeProvider.Cache<HealPacket>.Code;

    public int Size => Unsafe.SizeOf<HealPacket>();

    public int Encode(Span<byte> output) => output.UnsafeWrite(this);

    public static HealPacket Decode(ReadOnlySpan<byte> input) => input.UnsafeRead<HealPacket>();
}
