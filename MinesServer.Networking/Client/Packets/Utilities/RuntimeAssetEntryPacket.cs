using MinesServer.Utils;

namespace MinesServer.Networking.Client.Packets.Utilities
{
    public readonly record struct RuntimeAssetEntryPacket(string Filename, string ETag) : IClientPacket<RuntimeAssetEntryPacket>
    {
        public int Size =>
        sizeof(byte) + // Filename.Length
        Filename.Length + // Filename
        sizeof(byte) + // ETag.Length
        ETag.Length; // ETag

        public int Encode(Span<byte> output)
        {
            var writer = output.Writer();
            writer.WriteU1PrefixedASCII(Filename);
            writer.WriteU1PrefixedASCII(ETag);
            return writer.Position;
        }

        public static RuntimeAssetEntryPacket Decode(ReadOnlySpan<byte> input)
        {
            var reader = input.Reader();
            return new(
                reader.ReadU1PrefixedASCII(out _),
                reader.ReadU1PrefixedASCII(out _));
        }
    }
}
