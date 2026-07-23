using MinesServer.Networking.Shared;

namespace MinesServer.Networking.Connection;

public interface IConnection<TReceivePacket, TSendPacket> : IDisposable
    where TReceivePacket : INetworkPacket<TReceivePacket>
    where TSendPacket : INetworkPacket<TSendPacket>
{
    public void Connect();
    public void Disconnect();
    public void SendAsync(TSendPacket packet);
    public ConnectionStatus ConnectionStatus { get; }
    public event Action<TReceivePacket> OnReceived;
    public event Action OnConnected;
    public event Action OnDisconnected;
    public event Action OnDisconnecting;
    public event Action OnConnecting;
}
