using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MinesServer.Networking.Client.Packets.Actions;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct BuildGrayPacket() : IActionClientPacket<BuildGrayPacket>
{
    public byte PacketCode => ActionClientPacketCodeProvider.Cache<BuildGrayPacket>.Code;

    public int Size => Unsafe.SizeOf<BuildGrayPacket>();

    public int Encode(Span<byte> output) => output.UnsafeWrite(this);

    public static BuildGrayPacket Decode(ReadOnlySpan<byte> input) => input.UnsafeRead<BuildGrayPacket>();
}
