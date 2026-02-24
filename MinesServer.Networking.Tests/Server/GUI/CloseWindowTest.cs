using MinesServer.Networking.Server.Packets.GUI;

namespace MinesServer.Networking.Tests.Server.GUI;

internal class CloseWindowTest : RootServerPacketTest<CloseWindowPacket>
{
    public override CloseWindowPacket Packet => new();
}
