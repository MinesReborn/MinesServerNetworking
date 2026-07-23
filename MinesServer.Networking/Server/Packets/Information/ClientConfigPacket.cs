using MinesServer.Data;
using MinesServer.Networking.Shared.Packets;
using MinesServer.Utils;

namespace MinesServer.Networking.Server.Packets.Information;

public readonly record struct ClientConfigPacket(SoundConfigPacket SoundConfig, RendererMode Renderer, IReadOnlyList<StringPairPacket> Keybinds, IReadOnlyList<string> UnrenderedTextures) : IRootServerPacket<ClientConfigPacket>
{
    public ushort PacketCode => RootServerPacketCodeProvider.Cache<ClientConfigPacket>.Code;

    public int Size =>
        SoundConfig.Size + // SoundConfig
        sizeof(RendererMode) + // Renderer
        sizeof(byte) + // Keybinds.Length
        Keybinds.Sum(x => x.Size) + // Keybinds
        UnrenderedTextures.Sum(x => sizeof(byte) + x.Length); // UnrenderedTextures

    public int Encode(Span<byte> output)
    {
        var writer = output.Writer();
        writer.Write(SoundConfig);
        writer.Write(Renderer);
        writer.Write((byte)Keybinds.Count);
        foreach (var keybind in Keybinds)
            writer.Write(keybind);
        foreach (var texture in UnrenderedTextures)
            writer.WriteU1PrefixedASCII(texture);
        return writer.Position;
    }

    public static ClientConfigPacket Decode(ReadOnlySpan<byte> input)
    {
        var reader = input.Reader();
        var sounds = SoundConfigPacket.Decode(reader.Remaining);
        reader.Advance(sounds.Size);
        var renderer = reader.Read<RendererMode>();
        var keybinds = new StringPairPacket[reader.ReadU1()];
        for(int i = 0; i < keybinds.Length; i++)
        {
            var keybind = StringPairPacket.Decode(reader.Remaining);
            reader.Advance(keybind.Size);
            keybinds[i] = keybind;
        }
        var unrender = new List<string>();
        while (reader.CanRead)
            unrender.Add(reader.ReadU1PrefixedASCII(out _));
        return new(sounds, renderer, keybinds, unrender);
    }

    public bool Equals(ClientConfigPacket other) =>
        SoundConfig == other.SoundConfig &&
        Renderer == other.Renderer &&
        UnrenderedTextures.SequenceEqual(other.UnrenderedTextures);
}