using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MinesServer.Networking.Client.Packets.Actions;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct BzPacket() : IActionClientPacket<BzPacket>
{
    public byte PacketCode => ActionClientPacketCodeProvider.Cache<BzPacket>.Code;

    public int Size => Unsafe.SizeOf<BzPacket>();

    public int Encode(Span<byte> output) => output.UnsafeWrite(this);

    public static BzPacket Decode(ReadOnlySpan<byte> input) => input.UnsafeRead<BzPacket>();
}
