using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MinesServer.Networking.Client.Packets.Actions;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct ToggleAgressionPacket() : IActionClientPacket<ToggleAgressionPacket>
{
    public byte PacketCode => ActionClientPacketCodeProvider.Cache<ToggleAgressionPacket>.Code;

    public int Size => Unsafe.SizeOf<ToggleAgressionPacket>();

    public int Encode(Span<byte> output) => output.UnsafeWrite(this);

    public static ToggleAgressionPacket Decode(ReadOnlySpan<byte> input) => input.UnsafeRead<ToggleAgressionPacket>();
}

