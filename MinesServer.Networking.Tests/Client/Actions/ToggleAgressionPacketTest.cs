using MinesServer.Networking.Client.Packets.Actions;

namespace MinesServer.Networking.Tests.Client.Actions;

internal class ToggleAgressionPacketTest : PacketTest<ToggleAgressionPacket>
{
    public override ToggleAgressionPacket Packet => new();
}
