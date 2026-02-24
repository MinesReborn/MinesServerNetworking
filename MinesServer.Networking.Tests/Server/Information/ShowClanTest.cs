using MinesServer.Networking.Server.Packets.Information;

namespace MinesServer.Networking.Tests.Server.Information;

internal class ShowClanTest : RootServerPacketTest<ShowClanPacket>
{
    public override ShowClanPacket Packet => new(99);
}