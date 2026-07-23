using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MinesServer.Networking.Client.Packets.Inventory;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct UseItemPacket() : IRootClientPacket<UseItemPacket>
{
    public byte PacketCode => RootClientPacketCodeProvider.Cache<UseItemPacket>.Code;

    public int Size => Unsafe.SizeOf<UseItemPacket>();

    public int Encode(Span<byte> output) => output.UnsafeWrite(this);

    public static UseItemPacket Decode(ReadOnlySpan<byte> input) => input.UnsafeRead<UseItemPacket>();
}
