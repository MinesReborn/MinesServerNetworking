using MinesServer.Data;
using MinesServer.Networking.Server.Packets.Programmator;

namespace MinesServer.Networking.Tests.Server.Programmator;

internal class UpdateProgramTest : RootServerPacketTest<UpdateProgramPacket>
{
    public override UpdateProgramPacket Packet => new(123, [(ProgAction.BooleanAND, "", 0), (ProgAction.AddNumberToVar, "asd", 456)]);
}
