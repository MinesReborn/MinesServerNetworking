using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MinesServer.Networking.Server.Packets.Inventory;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct DeselectItemPacket() : IRootServerPacket<DeselectItemPacket>
{
    public ushort PacketCode => RootServerPacketCodeProvider.Cache<DeselectItemPacket>.Code;

    public readonly int Size => Unsafe.SizeOf<DeselectItemPacket>();

    public int Encode(Span<byte> output) => output.UnsafeWrite(this);

    public static DeselectItemPacket Decode(ReadOnlySpan<byte> input) => input.UnsafeRead<DeselectItemPacket>();
}
