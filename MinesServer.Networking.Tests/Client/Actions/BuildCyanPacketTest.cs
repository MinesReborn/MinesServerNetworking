using MinesServer.Networking.Client.Packets.Actions;

namespace MinesServer.Networking.Tests.Client.Actions;

internal class BuildCyanPacketTest : PacketTest<BuildCyanPacket>
{
    public override BuildCyanPacket Packet => new();
}
