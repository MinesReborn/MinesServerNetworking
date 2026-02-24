using MinesServer.Networking.Server.Packets.Information;

namespace MinesServer.Networking.Tests.Server.Information;

internal class HideClanTest : RootServerPacketTest<HideClanPacket>
{
    public override HideClanPacket Packet => new();
}
