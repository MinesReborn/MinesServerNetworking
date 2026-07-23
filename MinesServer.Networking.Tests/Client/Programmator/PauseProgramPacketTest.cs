using MinesServer.Networking.Client.Packets.Programmator;

namespace MinesServer.Networking.Tests.Client.Programmator;

internal class PauseProgramPacketTest : RootClientPacketTest<PauseProgramPacket>
{
    public override PauseProgramPacket Packet => new();
}
