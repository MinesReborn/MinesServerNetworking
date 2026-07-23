using MinesServer.Utils;

namespace MinesServer.Networking.Server.Packets.Chat;

public readonly record struct ChatListPacket(IReadOnlyList<(string Tag, string Name, ChatMessagePacket Message)> Chats) : IRootServerPacket<ChatListPacket>
{
    public ushort PacketCode => RootServerPacketCodeProvider.Cache<ChatListPacket>.Code;

    public int Size =>
        Chats.Sum(x => sizeof(byte) + x.Tag.Length + sizeof(byte) + x.Name.Length * 2 + x.Message.Size); // Chats

    public int Encode(Span<byte> output)
    {
        var writer = output.Writer();
        foreach(var chat in Chats)
        {
            writer.WriteU1PrefixedASCII(chat.Tag);
            writer.WriteU1PrefixedUtf16(chat.Name);
            writer.Write(chat.Message);
        }
        return writer.Position;
    }

    public static ChatListPacket Decode(ReadOnlySpan<byte> input)
    {
        var reader = input.Reader();
        var chats = new List<(string, string, ChatMessagePacket)>();
        while(reader.CanRead)
        {
            var tag = reader.ReadU1PrefixedASCII(out _);
            var name = reader.ReadU1PrefixedUtf16(out _);
            var msg = ChatMessagePacket.Decode(reader.Remaining);
            reader.Advance(msg.Size);
            chats.Add((tag, name, msg));
        }
        return new(chats);
    }

    public bool Equals(ChatListPacket other) => Chats.SequenceEqual(other.Chats);
}
