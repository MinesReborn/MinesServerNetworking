using MinesServer.Utils;
using System;
using System.Linq;

namespace MinesServer.Networking.Server.Packets.GUI.Components.Containers;

public record class GridPacket : ContainerComponentPacket, IGUIComponentPacket<GridPacket>
{
    public override byte PacketCode => GUIComponentPacketCodeProvider.Cache<GridPacket>.Code;

    public byte[] Columns { get; init; } = new byte[] { 0 };
    public byte[] Rows { get; init; } = new byte[] { 0 };

    public override int Size => base.Size
        + sizeof(byte) // Columns.Length
        + Columns.Length // Columns
        + sizeof(byte) // Rows.Length
        + Rows.Length; // Rows

    public override int Encode(Span<byte> output)
    {
        var writer = output.Writer();
        writer.Advance(base.Encode(output));
        writer.WriteU1PrefixedArray(Columns);
        writer.WriteU1PrefixedArray(Rows);
        return writer.Position;
    }

    public static GridPacket Decode(ReadOnlySpan<byte> input)
    {
        var reader = input.Reader();
        return new(ref reader);
    }

    protected GridPacket(ref MemoryReader reader) : base(ref reader)
    {
        Columns = reader.ReadU1PrefixedArray<byte>(out _);
        Rows = reader.ReadU1PrefixedArray<byte>(out _);
    }

    public GridPacket() : base() { }

    public virtual bool Equals(GridPacket other) =>
        base.Equals(other) &&
        Rows.SequenceEqual(other.Rows) &&
        Columns.SequenceEqual(other.Columns);
}
