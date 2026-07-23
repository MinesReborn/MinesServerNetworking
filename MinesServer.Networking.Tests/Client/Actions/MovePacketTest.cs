using MinesServer.Networking.Client.Packets.Movement;

namespace MinesServer.Networking.Tests.Client.Actions;

internal class MovePacketTest : PacketTest<MovePacket>
{
    public override MovePacket Packet => new(100, 200);
}
