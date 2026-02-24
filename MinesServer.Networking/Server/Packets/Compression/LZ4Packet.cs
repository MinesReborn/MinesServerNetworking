using K4os.Compression.LZ4;
using MinesServer.Networking.Exceptions;
using MinesServer.Utils;
using System;

namespace MinesServer.Networking.Server.Packets.Compression;

public readonly record struct LZ4Packet(IRootServerPacket Payload) : IRootServerPacket<LZ4Packet>, IUnreliableLengthPacket
{
    public ushort PacketCode => RootServerPacketCodeProvider.Cache<LZ4Packet>.Code;

    // There is no reliable way to predict the length of a compressed lz4 payload, so assume the worst and treat the payload as uncompressed.
    // This shouldn't affect encoding and decoding.
    public int Size => 
        sizeof(int) + // Uncompressed size
        LZ4Codec.MaximumOutputSize(Payload.Size);

    public int Encode(Span<byte> output)
    {
        var size = Size;
        Span<byte> encoded = size > 1024 * 1024 * 4 ? new byte[size].AsSpan() : stackalloc byte[size];
        var encw = encoded.Writer();
        encw.Write(Payload.PacketCode);
        encw.Write(Payload);
        var writer = output.Writer();
        writer.Write(encw.Position);
        return writer.Position + LZ4Codec.Encode(encoded, writer.Remaining, LZ4Level.L00_FAST);
    }

    public static LZ4Packet Decode(ReadOnlySpan<byte> input)
    {
        var reader = input.Reader();
        var len = LZ4Codec.MaximumOutputSize(reader.Read4());
        Span<byte> encoded = len > 1024 * 1024 * 4 ? new byte[len].AsSpan() : stackalloc byte[len];
        LZ4Codec.Decode(reader.Remaining, encoded);
        var innerReader = encoded.Reader();
        var code = innerReader.ReadU2();
        if (!RootServerPacketCodeProvider.TryGetDecoder(code, out var decoder))
            throw new PacketDecodeException("Unknown packet code");
        return new(decoder(innerReader.Remaining));
    }
}
