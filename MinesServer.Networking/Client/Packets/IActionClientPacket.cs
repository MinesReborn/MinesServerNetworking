namespace MinesServer.Networking.Client.Packets;

public interface IActionClientPacket : INetworkPacketBase
{
    public byte PacketCode { get; }
}
public interface IActionClientPacket<TSelf> : IClientPacket<TSelf>, IActionClientPacket where TSelf : IActionClientPacket<TSelf> { }
