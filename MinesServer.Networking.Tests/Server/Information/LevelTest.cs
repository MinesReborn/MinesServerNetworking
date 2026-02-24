using MinesServer.Networking.Server.Packets.Information;

namespace MinesServer.Networking.Tests.Server.Information;

internal class LevelTest : RootServerPacketTest<LevelPacket>
{
    public override LevelPacket Packet => new(50);
}
