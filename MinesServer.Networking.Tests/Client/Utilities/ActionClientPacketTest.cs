using MinesServer.Networking.Client.Packets.Actions;

namespace MinesServer.Networking.Tests.Client.Utilities;

internal class ActionClientPacketTest : RootClientPacketTest<ActionClientPacket>
{
    public override ActionClientPacket Packet => new(100, 200, new SuicidePacket());
}
