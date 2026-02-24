using MinesServer.Networking.Server.Packets.Connection;

namespace MinesServer.Networking.Tests.Server.Connection;

internal class PingTest : RootServerPacketTest<PingPacket>
{
    public override PingPacket Packet => new(DateTime.UtcNow.Ticks, 123);
}