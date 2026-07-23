using MinesServer.Networking.Client.Packets.Actions;

namespace MinesServer.Networking.Tests.Client.Actions;

internal class BuildWhitePacketTest : PacketTest<BuildWhitePacket>
{
    public override BuildWhitePacket Packet => new();
}
