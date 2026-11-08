using MinesServer.Utils;
using System;

namespace MinesServer.Networking.Client.Packets.Connection;

/// <summary>
/// Регистрация по нику и паролю. Шлётся после ClientHello с пустым/неизвестным
/// токеном; ответ сервера — AuthResultPacket (+ AuthTokenPacket при успехе).
/// </summary>
public readonly record struct AuthRegisterPacket(string Login, string Password) : IRootClientPacket<AuthRegisterPacket>
{
    public byte PacketCode => RootClientPacketCodeProvider.Cache<AuthRegisterPacket>.Code;

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

    public static AuthRegisterPacket Decode(ReadOnlySpan<byte> input)
    {
        var reader = input.Reader();
        return new(
            reader.ReadU2PrefixedUtf16(out _),
            reader.ReadU2PrefixedUtf16(out _));
    }
}
