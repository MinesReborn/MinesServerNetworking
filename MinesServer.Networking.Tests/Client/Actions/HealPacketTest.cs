using MinesServer.Networking.Client.Packets.Actions;

namespace MinesServer.Networking.Tests.Client.Actions;

internal class HealPacketTest : PacketTest<HealPacket>
{
    public override HealPacket Packet => new();
}
