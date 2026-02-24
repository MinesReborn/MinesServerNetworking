using MinesServer.Networking.Server.Packets.Information.StatusPanel;

namespace MinesServer.Networking.Tests.Server.Information.StatusPanel;

internal class ClearStatusTest : RootServerPacketTest<ClearStatusPacket>
{
    public override ClearStatusPacket Packet => new();
}