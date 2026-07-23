namespace MinesServer.Networking.Exceptions;

public class PacketDecodeException : NetworkException
{
    public PacketDecodeException(string message) : base(message) { }

    public PacketDecodeException(string message, Exception innerException) : base(message, innerException) { }
}
