namespace MinesServer.Networking;

public interface INetworkPacketBase
{
    /// <summary>
    /// Predictive length calculation. This *should* be faster than Encode().Length in all cases
    /// </summary>
    public int Size { get; }

    /// <summary>
    /// Encodes the packet into the specified span
    /// </summary>
    /// <remarks>
    /// Expects either a perfectly sized span or a span which length is at least enough to fit the encoded payload.
    /// </remarks>
    /// <returns>Number of bytes written</returns>
    public int Encode(Span<byte> output);
}
