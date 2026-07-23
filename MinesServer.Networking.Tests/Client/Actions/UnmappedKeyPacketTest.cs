using MinesServer.Networking.Client.Packets.Actions;

namespace MinesServer.Networking.Tests.Client.Actions;

internal class UnmappedKeyPacketTest : PacketTest<UnmappedKeyPacket>
{
    public override UnmappedKeyPacket Packet => new(42, true, false, false);
}
