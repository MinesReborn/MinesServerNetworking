using MinesServer.Networking.Client.Packets.Programmator;

namespace MinesServer.Networking.Tests.Client.Programmator;

internal class StopProgramPacketTest : RootClientPacketTest<StopProgramPacket>
{
    public override StopProgramPacket Packet => new();
}
