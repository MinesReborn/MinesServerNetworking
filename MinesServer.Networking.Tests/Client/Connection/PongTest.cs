using MinesServer.Networking.Client.Packets.Connection;

namespace MinesServer.Networking.Tests.Client.Connection;

internal class PongTest : RootClientPacketTest<PongPacket>
{
    public override PongPacket Packet => new(DateTime.UtcNow.Ticks);
}
