using MinesServer.Networking.Server.Packets.Information;

namespace MinesServer.Networking.Tests.Server.Information;

internal class DailyBonusStateTest : RootServerPacketTest<DailyBonusStatePacket>
{
    public override DailyBonusStatePacket Packet => new(true);
}