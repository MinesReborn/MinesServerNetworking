namespace MinesServer.Networking.Shared.Packets;

public interface IKeyValuePairPacket<TKey, TValue> : INetworkPacketBase
{
    public TKey Key { get; init; }
    public TValue Value { get; init; }
}
