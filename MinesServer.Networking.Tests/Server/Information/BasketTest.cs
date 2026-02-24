using MinesServer.Networking.Server.Packets.Information;

namespace MinesServer.Networking.Tests.Server.Information;

internal class BasketTest : RootServerPacketTest<BasketPacket>
{
    public override BasketPacket Packet => new(100, [1L, 2L, 1000L, long.MaxValue]);
}
