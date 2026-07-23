using MinesServer.Networking.Client.Packets.Programmator;

namespace MinesServer.Networking.Tests.Client.Programmator;

internal class StartProgramPacketTest : RootClientPacketTest<StartProgramPacket>
{
    public override StartProgramPacket Packet => new();
}
