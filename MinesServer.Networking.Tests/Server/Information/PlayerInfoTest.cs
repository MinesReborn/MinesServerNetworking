using MinesServer.Networking.Server.Packets.Information;

namespace MinesServer.Networking.Tests.Server.Information;

internal class PlayerInfoTest : RootServerPacketTest<PlayerInfoPacket>
{
    public override PlayerInfoPacket Packet => new(1, 1001, "TestPlayer");
}
