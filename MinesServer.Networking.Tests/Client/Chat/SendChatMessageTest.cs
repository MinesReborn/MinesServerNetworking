using MinesServer.Networking.Client.Packets.Chat;

namespace MinesServer.Networking.Tests.Client.Chat;

internal class SendChatMessageTest : RootClientPacketTest<SendChatMessagePacket>
{
    public override SendChatMessagePacket Packet => new("FED", "Hello world! Привет, мир!");
}

