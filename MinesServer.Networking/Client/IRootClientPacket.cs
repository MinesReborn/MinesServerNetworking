namespace MinesServer.Networking.Client;

public interface IRootClientPacket : INetworkPacketBase
{
    public byte PacketCode { get; }
}
public interface IRootClientPacket<TSelf> : IClientPacket<TSelf>, IRootClientPacket where TSelf : IRootClientPacket<TSelf> { }
