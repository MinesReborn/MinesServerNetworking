using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MinesServer.Networking.Server.Packets.Information;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct HideClanPacket() : IRootServerPacket<HideClanPacket>
{
    public ushort PacketCode => RootServerPacketCodeProvider.Cache<HideClanPacket>.Code;

    public readonly int Size => Unsafe.SizeOf<HideClanPacket>();

    public int Encode(Span<byte> output) => output.UnsafeWrite(this);

    public static HideClanPacket Decode(ReadOnlySpan<byte> input) => input.UnsafeRead<HideClanPacket>();
}