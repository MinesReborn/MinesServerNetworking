using MinesServer.Networking.Server.Packets.World;

namespace MinesServer.Networking.Tests.Server.World;

internal class RemovePackTest : PacketTest<RemovePackPacket>
{
    public override RemovePackPacket Packet => new(789, 987);
}