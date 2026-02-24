using MinesServer.Networking.Server.Packets.Connection;

namespace MinesServer.Networking.Tests.Server.Connection;

internal class DisconnectTest : RootServerPacketTest<DisconnectPacket>
{
    public override DisconnectPacket Packet => new("Kicked for inactivity.");
}
