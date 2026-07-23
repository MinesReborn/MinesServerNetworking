using MinesServer.Networking.Client.Packets.Inventory;

namespace MinesServer.Networking.Tests.Client.Inventory;

internal class DeselectItemTest : RootClientPacketTest<DeselectItemPacket>
{
    public override DeselectItemPacket Packet => new();
}