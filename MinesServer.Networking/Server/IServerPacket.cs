namespace MinesServer.Networking.Server;

public interface IServerPacket<TSelf> : INetworkPacket<TSelf> where TSelf : IServerPacket<TSelf> { }
