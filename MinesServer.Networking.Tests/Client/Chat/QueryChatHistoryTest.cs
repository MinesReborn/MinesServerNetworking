using MinesServer.Networking.Client.Packets.Chat;

namespace MinesServer.Networking.Tests.Client.Chat;

internal class QueryChatHistoryTest : RootClientPacketTest<QueryChatHistoryPacket>
{
    public override QueryChatHistoryPacket Packet => new("FED", 1234567890);
}

