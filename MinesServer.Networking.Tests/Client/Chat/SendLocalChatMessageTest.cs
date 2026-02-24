using MinesServer.Networking.Client.Packets.Chat;

namespace MinesServer.Networking.Tests.Client.Chat;

internal class SendLocalChatMessageTest : RootClientPacketTest<SendLocalChatMessagePacket>
{
    public override SendLocalChatMessagePacket Packet => new("This is a local message. Пример локального сообщения.");
}

