using MinesServer.Networking.Client.Packets.Utilities;

namespace MinesServer.Networking.Tests.Client.Utilities;

internal class RuntimeAssetRequestPacketTest : RootClientPacketTest<RuntimeAssetRequestPacket>
{
    public override RuntimeAssetRequestPacket Packet => new([new RuntimeAssetEntryPacket("test.txt", "abc123")]);
}
