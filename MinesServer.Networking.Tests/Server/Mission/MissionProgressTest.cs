using MinesServer.Networking.Server.Packets.Mission;

namespace MinesServer.Networking.Tests.Server.Mission;

internal class MissionProgressTest : RootServerPacketTest<MissionProgressPacket>
{
    public override MissionProgressPacket Packet => new(75, 200);
}