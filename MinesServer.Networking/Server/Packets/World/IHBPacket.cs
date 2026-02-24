namespace MinesServer.Networking.Server.Packets.World;

public interface IHBPacket : INetworkPacketBase
{
    public byte PacketCode { get; }
}
public interface IHBPacket<TSelf> : IServerPacket<TSelf>, IHBPacket where TSelf : IHBPacket<TSelf> { }
