using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MinesServer.Networking.Server.Packets.Information;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct AggressionStatePacket(bool Enabled) : IRootServerPacket<AggressionStatePacket>
{
    public ushort PacketCode => RootServerPacketCodeProvider.Cache<AggressionStatePacket>.Code;

    public readonly int Size => Unsafe.SizeOf<AggressionStatePacket>();

    public int Encode(Span<byte> output) => output.UnsafeWrite(this);

    public static AggressionStatePacket Decode(ReadOnlySpan<byte> input) => input.UnsafeRead<AggressionStatePacket>();
}
