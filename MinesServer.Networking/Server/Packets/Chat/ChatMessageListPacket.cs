using MinesServer.Utils;
using System;
using System.Linq;
using System.Collections.Generic;

namespace MinesServer.Networking.Server.Packets.Chat;

public readonly record struct ChatMessageListPacket(string Tag, IReadOnlyList<ChatMessagePacket> Messages) : IRootServerPacket<ChatMessageListPacket>
{
    public ushort PacketCode => RootServerPacketCodeProvider.Cache<ChatMessageListPacket>.Code;

    public int Size =>
        sizeof(byte) + // Tag.Length
        Tag.Length + // Tag
        sizeof(byte) + // Messages.Length
        Messages.Sum(x => x.Size); // Messages

    public int Encode(Span<byte> output)
    {
        var writer = output.Writer();
        writer.WriteU1PrefixedASCII(Tag);
        writer.Write((byte)Messages.Count);
        foreach (var message in Messages)
            writer.Write(message);
        return writer.Position;
    }

    public static ChatMessageListPacket Decode(ReadOnlySpan<byte> input)
    {
        var reader = input.Reader();
        var tag = reader.ReadU1PrefixedASCII(out _);
        var messages = new ChatMessagePacket[reader.ReadU1()];
        for(int i = 0;i < messages.Length;i++)
        {
            var msg = ChatMessagePacket.Decode(reader.Remaining);
            reader.Advance(msg.Size);
            messages[i] = msg;
        }
        return new(tag, messages);
    }
}
