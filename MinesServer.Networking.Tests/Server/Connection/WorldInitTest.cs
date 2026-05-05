using MinesServer.Data;
using MinesServer.Networking.Server.Packets.Connection;

namespace MinesServer.Networking.Tests.Server.Connection;

internal class WorldInitTest : RootServerPacketTest<WorldInitPacket>
{
    public override WorldInitPacket Packet => new(
        "test",
        "Тестовый мир",
        10,
        10,
        [
            new(CellConfigProperties.Passable, CellDistortionType.Neutral, CellAnimationType.None, 0, 0, 0, 0),
            new(CellConfigProperties.Breakable, CellDistortionType.Block, CellAnimationType.Blinking, 5, 1, -1, 1)
        ],
        [
            [1, 2, 3],
            [4, 5, 6]
        ]);
}