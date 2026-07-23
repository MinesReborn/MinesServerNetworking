namespace MinesServer.Networking.Exceptions;

public class NetworkException : Exception
{
    public NetworkException(string message) : base(message) { }

    public NetworkException() : base() { }

    public NetworkException(string message, Exception innerException) : base(message, innerException) { }
}
