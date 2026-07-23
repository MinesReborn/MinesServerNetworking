using MinesServer.Networking.Server.Packets.Programmator;

namespace MinesServer.Networking.Tests.Server.Programmator;

internal class OpenProgrammatorPacketTest : RootServerPacketTest<OpenProgrammatorPacket>
{
    public override OpenProgrammatorPacket Packet => new();
}
