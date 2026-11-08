using MinesServer.Utils;
using System;

namespace MinesServer.Networking.Client.Packets.Connection;

/// <summary>
/// Вход по нику и паролю. Шлётся после ClientHello, когда сохранённый токен
/// отсутствует или не подошёл; ответ сервера — AuthResultPacket (+ AuthTokenPacket при успехе).
/// Строки U2-prefixed UTF16: ник может быть кириллицей.
/// </summary>
public readonly record struct AuthLoginPacket(string Login, string Password) : IRootClientPacket<AuthLoginPacket>
{
    public byte PacketCode => RootClientPacketCodeProvider.Cache<AuthLoginPacket>.Code;

    public int Size =>
        sizeof(ushort) + Login.Length * 2 + // Login
        sizeof(ushort) + Password.Length * 2; // Password

    public int Encode(Span<byte> output)
    {
        var writer = output.Writer();
        writer.WriteU2PrefixedUtf16(Login);
        writer.WriteU2PrefixedUtf16(Password);
        return writer.Position;
    }

    public static AuthLoginPacket Decode(ReadOnlySpan<byte> input)
    {
        var reader = input.Reader();
        return new(
            reader.ReadU2PrefixedUtf16(out _),
            reader.ReadU2PrefixedUtf16(out _));
    }
}
