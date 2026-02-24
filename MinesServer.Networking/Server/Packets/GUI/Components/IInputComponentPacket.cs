namespace MinesServer.Networking.Server.Packets.GUI.Components;

public interface IInputComponentPacket : INamedComponentPacket
{
    public bool IsEnabled { get; init; }
}
public interface IInputComponentPacket<TValue> : IInputComponentPacket where TValue : notnull
{
    public TValue DefaultValue { get; init; }
}
