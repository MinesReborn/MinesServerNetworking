using MinesServer.Networking.Server.Packets.Information;

namespace MinesServer.Networking.Tests.Server.Information;

internal class HealthTest : RootServerPacketTest<HealthPacket>
{
    public override HealthPacket Packet => new(95, 120);
}
