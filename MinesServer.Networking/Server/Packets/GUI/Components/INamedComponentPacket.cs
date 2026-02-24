namespace MinesServer.Networking.Server.Packets.GUI.Components;

public interface INamedComponentPacket : IGUIComponentPacket
{
    public string Name { get; init; }
}
