using MinesServer.Networking.Client.Packets.Actions;

namespace MinesServer.Networking.Tests.Client.Actions;

internal class ToggleAutoDigPacketTest : PacketTest<ToggleAutoDigPacket>
{
    public override ToggleAutoDigPacket Packet => new();
}
