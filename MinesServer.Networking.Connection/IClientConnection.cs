using MinesServer.Networking.Client.Packets;
using MinesServer.Networking.Server.Packets;

namespace MinesServer.Networking.Connection;

public interface IClientConnection : IConnection<ClientPacket, ServerPacket> { }
