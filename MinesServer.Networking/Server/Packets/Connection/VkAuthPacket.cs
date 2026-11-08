using MinesServer.Utils;
using System;

namespace MinesServer.Networking.Server.Packets.Connection;

/// <summary>
/// Данные VK-входа для экрана входа: sid текущей сессии (корреляция с веб-колбэком
/// /oauth/vk/code?uniq=sid) и готовая ссылка авторизации VK ID (кодовый поток,
/// PKCE собирается сервером — клиент только открывает её в браузере).
/// Сервер шлёт в состоянии ожидания входа (после ClientHello без валидного токена).
/// </summary>
public readonly record struct VkAuthPacket(string Sid, string AuthUrl) : IRootServerPacket<VkAuthPacket>
{
    public ushort PacketCode => RootServerPacketCodeProvider.Cache<VkAuthPacket>.Code;

    public int Size =>
        sizeof(byte) + Sid.Length + // Sid
        sizeof(ushort) + AuthUrl.Length; // AuthUrl

    public int Encode(Span<byte> output)
    {
        var writer = output.Writer();
        writer.WriteU1PrefixedASCII(Sid);
        writer.WriteU2PrefixedASCII(AuthUrl);
        return writer.Position;
    }

    public static VkAuthPacket Decode(ReadOnlySpan<byte> input)
    {
        var reader = input.Reader();
        return new(
            reader.ReadU1PrefixedASCII(out _),
            reader.ReadU2PrefixedASCII(out _));
    }
}
