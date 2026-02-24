using MinesServer.Networking.Server.Packets.Inventory;

namespace MinesServer.Networking.Tests.Server.Inventory;

internal class DeselectItemTest : RootServerPacketTest<DeselectItemPacket>
{
    public override DeselectItemPacket Packet => new();
}
