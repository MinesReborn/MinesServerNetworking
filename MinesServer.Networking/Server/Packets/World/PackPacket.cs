using MinesServer.Data;
using System.Runtime.CompilerServices;

namespace MinesServer.Networking.Server.Packets.World;

public readonly record struct PackPacket(ushort X, ushort Y, PackType PackCode, byte Variant, byte LinkedClan) : IHBPacket<PackPacket>
{
    public byte PacketCode => HBPacketCodeProvider.Cache<PackPacket>.Code;

    public int Size => Unsafe.SizeOf<PackPacket>();

    public int Encode(Span<byte> output) => output.UnsafeWrite(this);

    public static PackPacket Decode(ReadOnlySpan<byte> input) => input.UnsafeRead<PackPacket>();
}
