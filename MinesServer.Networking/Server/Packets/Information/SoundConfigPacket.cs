using MinesServer.Utils;
using System;
using System.Linq;
using System.Collections.Generic;

namespace MinesServer.Networking.Server.Packets.Information;

public readonly record struct SoundConfigPacket(byte Master,  IDictionary<string, byte> IndividualSounds) : IServerPacket<SoundConfigPacket>
{
    public int Size =>
        sizeof(byte) + // Master
        sizeof(ushort) + // IndividualSounds.Length
        IndividualSounds.Sum(x => sizeof(byte) + x.Key.Length + sizeof(byte)); // IndividualSounds

    public int Encode(Span<byte> output)
    {
        var writer = output.Writer();
        writer.Write(Master);
        writer.Write((ushort)IndividualSounds.Count);
        foreach (var sound in IndividualSounds)
        {
            writer.WriteU1PrefixedASCII(sound.Key);
            writer.Write(sound.Value);
        }
        return writer.Position;
    }

    public static SoundConfigPacket Decode(ReadOnlySpan<byte> input)
    {
        var reader = input.Reader();
        var master = reader.ReadU1();
        Dictionary<string, byte> sounds = new();
        var count = reader.ReadU2();
        for(int i = 0; i < count; i++)
            sounds.Add(reader.ReadU1PrefixedASCII(out _), reader.ReadU1());
        return new(master, sounds);
    }

    public bool Equals(SoundConfigPacket other) =>
        Master == other.Master &&
        IndividualSounds.SequenceEqual(other.IndividualSounds);
}
