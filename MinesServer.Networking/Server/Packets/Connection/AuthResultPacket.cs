using MinesServer.Utils;
using System;

namespace MinesServer.Networking.Server.Packets.Connection;

/// <summary>
/// Результат входа/регистрации по нику и паролю. Значения кодов стабильны
/// (клиент локализует по номеру), новые коды добавляются только в конец.
/// </summary>
public readonly record struct AuthResultPacket(byte Code) : IRootServerPacket<AuthResultPacket>
{
    public const byte Ok = 0;
    public const byte BadFormat = 1;
    public const byte LoginTaken = 2;
    public const byte BadCredentials = 3;
    public const byte Banned = 4;
    public const byte NotExpected = 5;
    public const byte TryLater = 6;
    public const byte StaleToken = 7;

    public ushort PacketCode => RootServerPacketCodeProvider.Cache<AuthResultPacket>.Code;

    public int Size => sizeof(byte); // Code

    public int Encode(Span<byte> output)
    {
        var writer = output.Writer();
        writer.Write(Code);
        return writer.Position;
    }

    public static AuthResultPacket Decode(ReadOnlySpan<byte> input) => new(input.Reader().ReadU1());
}
