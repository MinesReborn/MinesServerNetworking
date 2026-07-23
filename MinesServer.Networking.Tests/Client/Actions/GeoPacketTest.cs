using MinesServer.Networking.Client.Packets.Actions;

namespace MinesServer.Networking.Tests.Client.Actions;

internal class GeoPacketTest : PacketTest<GeoPacket>
{
    public override GeoPacket Packet => new();
}
