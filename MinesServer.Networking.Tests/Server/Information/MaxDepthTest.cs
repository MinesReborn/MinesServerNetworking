using MinesServer.Networking.Server.Packets.Information;

namespace MinesServer.Networking.Tests.Server.Information;

internal class MaxDepthTest : RootServerPacketTest<MaxDepthPacket>
{
    public override MaxDepthPacket Packet => new(5000);
}