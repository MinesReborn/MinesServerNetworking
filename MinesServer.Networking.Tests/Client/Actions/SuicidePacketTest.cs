using MinesServer.Networking.Client.Packets.Actions;

namespace MinesServer.Networking.Tests.Client.Actions;

internal class SuicidePacketTest : PacketTest<SuicidePacket>
{
    public override SuicidePacket Packet => new();
}
