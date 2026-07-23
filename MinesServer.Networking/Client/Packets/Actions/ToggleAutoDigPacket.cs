using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MinesServer.Networking.Client.Packets.Actions;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct ToggleAutoDigPacket() : IActionClientPacket<ToggleAutoDigPacket>
{
    public byte PacketCode => ActionClientPacketCodeProvider.Cache<ToggleAutoDigPacket>.Code;

    public int Size => Unsafe.SizeOf<ToggleAutoDigPacket>();

    public int Encode(Span<byte> output) => output.UnsafeWrite(this);

    public static ToggleAutoDigPacket Decode(ReadOnlySpan<byte> input) => input.UnsafeRead<ToggleAutoDigPacket>();
}
