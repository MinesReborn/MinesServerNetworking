using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MinesServer.Networking.Server.Packets.Information.StatusPanel;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct ClearStatusPacket : IRootServerPacket<ClearStatusPacket>
{
    public ushort PacketCode => RootServerPacketCodeProvider.Cache<ClearStatusPacket>.Code;

    public readonly int Size => Unsafe.SizeOf<ClearStatusPacket>();

    public int Encode(Span<byte> output) => output.UnsafeWrite(this);

    public static ClearStatusPacket Decode(ReadOnlySpan<byte> input) => input.UnsafeRead<ClearStatusPacket>();
}