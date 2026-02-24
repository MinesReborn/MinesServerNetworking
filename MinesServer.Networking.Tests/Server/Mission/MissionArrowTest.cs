using MinesServer.Networking.Server.Packets.Mission;

namespace MinesServer.Networking.Tests.Server.Mission;

internal class MissionArrowTest : RootServerPacketTest<MissionArrowPacket>
{
    public override MissionArrowPacket Packet => new(1234, 5678);
}
