using MinesServer.Networking.Shared.Packets;

namespace MinesServer.Networking.Tests.Shared;

internal class StringPairTest : PacketTest<StringPairPacket>
{
    public override StringPairPacket Packet => new("test_key", "Test value with some unicode chars: привет");
}
