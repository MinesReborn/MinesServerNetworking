using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MinesServer.Networking.Server.Packets.Programmator;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct OpenProgrammatorPacket : IRootServerPacket<OpenProgrammatorPacket>
{
    public ushort PacketCode => RootServerPacketCodeProvider.Cache<OpenProgrammatorPacket>.Code;

    public readonly int Size => Unsafe.SizeOf<OpenProgrammatorPacket>();

    public int Encode(Span<byte> output) => output.UnsafeWrite(this);

    public static OpenProgrammatorPacket Decode(ReadOnlySpan<byte> input) => input.UnsafeRead<OpenProgrammatorPacket>();
}