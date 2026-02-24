using MinesServer.Networking.Client.Packets;
using MinesServer.Networking.Server.Packets;

namespace MinesServer.Networking.Connection;

public interface IServerConnection : IConnection<ServerPacket, ClientPacket> { }