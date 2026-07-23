namespace MinesServer.Networking.Server.Packets.GUI.Components;

public interface IContainerComponentPacket : IGUIComponentPacket
{
    public IReadOnlyList<IGUIComponentPacket> Children { get; init; }
}
