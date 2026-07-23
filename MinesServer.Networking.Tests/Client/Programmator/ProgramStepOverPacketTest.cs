using MinesServer.Networking.Client.Packets.Programmator;

namespace MinesServer.Networking.Tests.Client.Programmator;

internal class ProgramStepOverPacketTest : RootClientPacketTest<ProgramStepOverPacket>
{
    public override ProgramStepOverPacket Packet => new();
}
