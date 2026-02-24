using MinesServer.Networking.Server.Packets.GUI;

namespace MinesServer.Networking.Tests.Server.GUI;

internal class MarginsTest : PacketTest<Margins>
{
    public override Margins Packet => new(1, 2, 3, 4);
}
