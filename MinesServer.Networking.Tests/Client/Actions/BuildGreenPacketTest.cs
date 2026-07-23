using MinesServer.Networking.Client.Packets.Actions;

namespace MinesServer.Networking.Tests.Client.Actions;

internal class BuildGreenPacketTest : PacketTest<BuildGreenPacket>
{
    public override BuildGreenPacket Packet => new();
}
