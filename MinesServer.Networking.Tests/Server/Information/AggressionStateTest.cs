using MinesServer.Networking.Server.Packets.Information;

namespace MinesServer.Networking.Tests.Server.Information;

internal class AggressionStateTest : RootServerPacketTest<AggressionStatePacket>
{
    public override AggressionStatePacket Packet => new(true);
}