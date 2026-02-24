namespace MinesServer.Networking.Server;

public interface IRootServerPacket : INetworkPacketBase
{
    public ushort PacketCode { get; }
}
public interface IRootServerPacket<TSelf> : IServerPacket<TSelf>, IRootServerPacket where TSelf : IRootServerPacket<TSelf> { }
