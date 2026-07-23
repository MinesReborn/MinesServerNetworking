using MinesServer.Data;
using MinesServer.Networking.Client.Packets.Inventory;

namespace MinesServer.Networking.Tests.Client.Inventory;

internal class SelectItemPacketTest : RootClientPacketTest<SelectItemPacket>
{
    public override SelectItemPacket Packet => new(ItemType.Teleport);
}
