namespace MinesServer.Networking;

public interface INetworkPacket<TSelf> : INetworkPacketBase where TSelf : INetworkPacket<TSelf>
{
#if NET7_0_OR_GREATER
    /// <summary>
    /// Reads the packet from the specified span
    /// </summary>
    /// <remarks>
    /// Expects either a perfectly sized span or a span which length is at least enough to fit the encoded payload.
    /// </remarks>
    /// <returns>The decoded packet</returns>
    public abstract static TSelf Decode(ReadOnlySpan<byte> input);
#endif
}