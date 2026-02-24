using MinesServer.Networking.Server.Packets.World;

namespace MinesServer.Networking.Tests.Server.World;

internal class RobotInfoPacketTest : RootServerPacketTest<RobotInfoPacket>
{
    public override RobotInfoPacket Packet => new(
    101,
    3,
    "fatty",
    "rainbow",
    "Darkar25");
}