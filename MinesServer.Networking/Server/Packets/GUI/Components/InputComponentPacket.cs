using MinesServer.Utils;

namespace MinesServer.Networking.Server.Packets.GUI.Components;

public abstract record class InputComponentPacket<TValue> : GUIComponentPacket, IInputComponentPacket<TValue> where TValue : notnull
{
    public bool IsEnabled { get; init; } = true;
    public string Name { get; init; } = null!;
    public abstract TValue DefaultValue { get; init; }

    public override int Size => base.Size
        + sizeof(bool) // IsEnabled
        + sizeof(byte) // Name.Length
        + Name.Length; // Name

    public override int Encode(Span<byte> output)
    {
        var writer = output.Writer();
        writer.Advance(base.Encode(output));
        writer.WriteU1PrefixedASCII(Name);
        writer.Write(IsEnabled);
        return writer.Position;
    }

    protected InputComponentPacket(ref MemoryReader reader) : base(ref reader)
    {
        Name = reader.ReadU1PrefixedASCII(out _);
        IsEnabled = reader.Read<bool>();
    }

    protected InputComponentPacket() : base() { }

    public virtual bool Equals(InputComponentPacket<TValue>? other) =>
        base.Equals(other) &&
        other.Name == Name &&
        other.IsEnabled == IsEnabled &&
        other.DefaultValue.Equals(DefaultValue);
}
