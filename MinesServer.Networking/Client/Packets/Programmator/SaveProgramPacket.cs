using MinesServer.Data;
using MinesServer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MinesServer.Networking.Client.Packets.Programmator;

public readonly record struct SaveProgramPacket(int ProgramId, bool SaveAndRun, IReadOnlyList<(ProgAction Operator, string Label, string Value)> Program) : IRootClientPacket<SaveProgramPacket>
{
    public byte PacketCode => RootClientPacketCodeProvider.Cache<SaveProgramPacket>.Code;

    public int Size =>
        sizeof(int) + // ProgramId
        sizeof(bool) + // SaveAndRun
        Program.Sum(x => sizeof(ProgAction) + sizeof(byte) + x.Label.Length * 2 + sizeof(byte) + x.Value.Length * 2); // Program

    public int Encode(Span<byte> output)
    {
        var writer = output.Writer();
        writer.Write(ProgramId);
        writer.Write(SaveAndRun);
        foreach(var op in Program)
        {
            writer.Write(op.Operator);
            writer.WriteU1PrefixedUtf16(op.Label);
            writer.WriteU1PrefixedUtf16(op.Value);
        }
        return writer.Position;
    }

    public static SaveProgramPacket Decode(ReadOnlySpan<byte> input)
    {
        var reader = input.Reader();
        var id = reader.Read4();
        var sar = reader.Read<bool>();
        var prog = new List<(ProgAction, string, string)>();
        while (reader.CanRead)
            prog.Add((reader.Read<ProgAction>(), reader.ReadU1PrefixedUtf16(out _), reader.ReadU1PrefixedUtf16(out _)));
        return new(id, sar, prog);
    }

    public bool Equals(SaveProgramPacket other) =>
        ProgramId == other.ProgramId &&
        SaveAndRun == other.SaveAndRun &&
        Program.SequenceEqual(other.Program);
}
