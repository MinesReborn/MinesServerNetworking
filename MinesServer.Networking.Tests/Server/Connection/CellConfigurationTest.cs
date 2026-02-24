using MinesServer.Data;
using MinesServer.Networking.Server.Packets.Connection;

namespace MinesServer.Networking.Tests.Server.Connection;

internal class CellConfigurationTest : PacketTest<CellConfigurationPacket>
{
    public override CellConfigurationPacket Packet => new(
        CellConfigProperties.Passable | CellConfigProperties.Breakable,
        CellAnimationType.Shimmer,
        15,
        3,
        -1,
        2);
}