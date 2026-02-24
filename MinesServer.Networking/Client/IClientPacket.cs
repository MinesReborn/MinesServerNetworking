namespace MinesServer.Networking.Client;

public interface IClientPacket<TSelf> : INetworkPacket<TSelf> where TSelf : IClientPacket<TSelf> { }
