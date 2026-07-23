using MinesServer.Networking.Client.Packets.Programmator;

namespace MinesServer.Networking.Tests.Client.Programmator;

internal class ProgramStepOutPacketTest : RootClientPacketTest<ProgramStepOutPacket>
{
    public override ProgramStepOutPacket Packet => new();
}
