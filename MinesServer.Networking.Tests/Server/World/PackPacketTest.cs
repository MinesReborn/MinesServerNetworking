using MinesServer.Data;
using MinesServer.Networking.Server.Packets.World;

namespace MinesServer.Networking.Tests.Server.World;

internal class PackPacketTest : PacketTest<PackPacket>
{
    public override PackPacket Packet => new(123, 456, PackType.Clans, 2, 78);
}