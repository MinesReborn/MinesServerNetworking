using MinesServer.Data;
using MinesServer.Networking.Server.Packets.Inventory;
using System.Collections;

namespace MinesServer.Networking.Tests.Server.Inventory;

internal class SelectItemTest : RootServerPacketTest<SelectItemPacket>
{
    public override SelectItemPacket Packet => new(
        ItemType.ProtonBomb,
        "Протонная бомба",
        "Взрывает 8 клеток вокруг.",
        3,
        3,
        5,
        true,
        new BitArray(Enumerable.Range(0, 64).Select(x => Random.Shared.Next(0, 2) == 0).ToArray()));
}