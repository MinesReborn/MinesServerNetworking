using MinesServer.Networking.Server.Packets.Information.StatusPanel;

namespace MinesServer.Networking.Tests.Server.Information.StatusPanel;

internal class ClearStatusLineTest : RootServerPacketTest<ClearStatusLinePacket>
{
    public override ClearStatusLinePacket Packet => new("buff_status");
}