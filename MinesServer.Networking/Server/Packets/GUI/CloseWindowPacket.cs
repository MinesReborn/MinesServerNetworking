using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MinesServer.Networking.Server.Packets.GUI;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct CloseWindowPacket() : IRootServerPacket<CloseWindowPacket>
{
    public ushort PacketCode => RootServerPacketCodeProvider.Cache<CloseWindowPacket>.Code;

    public readonly int Size => Unsafe.SizeOf<CloseWindowPacket>();

    public int Encode(Span<byte> output) => output.UnsafeWrite(this);

    public static CloseWindowPacket Decode(ReadOnlySpan<byte> input) => input.UnsafeRead<CloseWindowPacket>();
}
