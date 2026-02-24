using MinesServer.Networking.Exceptions;
using MinesServer.Utils;
using System;
using System.Linq;
using System.Collections.Generic;

namespace MinesServer.Networking.Server.Packets.World;

public readonly record struct HBPacket(IReadOnlyList<IHBPacket> Payload) : IRootServerPacket<HBPacket>
{
    public ushort PacketCode => RootServerPacketCodeProvider.Cache<HBPacket>.Code;

    public int Size =>
        sizeof(ushort) + // Payload.Length
        Payload.Sum(x => x.Size); // Payload

    public int Encode(Span<byte> output)
    {
        var writer = output.Writer();
        writer.Write((ushort)Payload.Count);
        foreach (var packet in Payload)
        {
            writer.Write(packet.PacketCode);
            writer.Write(packet);
        }
        return writer.Position;
    }

    public static HBPacket Decode(ReadOnlySpan<byte> input)
    {
        var reader = input.Reader();
        var packets = new IHBPacket[reader.ReadU2()];
        for(int i = 0; i < packets.Length;i++)
        {
            if (!HBPacketCodeProvider.TryGetDecoder(reader.ReadU1(), out var decoder))
                throw new PacketDecodeException("Unknown packet code");
            var packet = decoder(reader.Remaining);
            packets[i] = packet;
            reader.Advance(packet.Size);
        }
        return new(packets);
    }

    public bool Equals(HBPacket other) =>
        Payload.SequenceEqual(other.Payload);
}
