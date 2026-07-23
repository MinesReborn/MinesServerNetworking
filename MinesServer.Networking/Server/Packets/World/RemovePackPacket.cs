using System;
using System.Runtime.CompilerServices;

namespace MinesServer.Networking.Server.Packets.World;

public readonly record struct RemovePackPacket(ushort X, ushort Y) : IHBPacket<RemovePackPacket>
{
    public byte PacketCode => HBPacketCodeProvider.Cache<RemovePackPacket>.Code;

    public int Size => Unsafe.SizeOf<RemovePackPacket>();

    public int Encode(Span<byte> output) => output.UnsafeWrite(this);

    public static RemovePackPacket Decode(ReadOnlySpan<byte> input) => input.UnsafeRead<RemovePackPacket>();
}