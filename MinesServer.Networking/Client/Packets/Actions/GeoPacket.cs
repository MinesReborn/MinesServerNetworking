using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MinesServer.Networking.Client.Packets.Actions;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct GeoPacket() : IActionClientPacket<GeoPacket>
{
    public byte PacketCode => ActionClientPacketCodeProvider.Cache<GeoPacket>.Code;

    public int Size => Unsafe.SizeOf<GeoPacket>();

    public int Encode(Span<byte> output) => output.UnsafeWrite(this);

    public static GeoPacket Decode(ReadOnlySpan<byte> input) => input.UnsafeRead<GeoPacket>();
}
