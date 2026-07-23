using MinesServer.Data;
using MinesServer.Networking.Client.Packets.Programmator;

namespace MinesServer.Networking.Tests.Client.Programmator;

internal class SaveProgramPacketTest : RootClientPacketTest<SaveProgramPacket>
{
    public override SaveProgramPacket Packet => new(42, true, [(ProgAction.BooleanAND, "x", "y")]);
}
