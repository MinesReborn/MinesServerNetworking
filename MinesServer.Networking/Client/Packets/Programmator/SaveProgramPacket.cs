using MinesServer.Data;
using MinesServer.Utils;
using System;
using System.Linq;
using System.Collections.Generic;

namespace MinesServer.Networking.Client.Packets.Programmator;

public readonly record struct SaveProgramPacket(int ProgramId, bool SaveAndRun, IReadOnlyList<(ProgAction Operator, string Label, long Value)> Program) : IRootClientPacket<SaveProgramPacket>
{
    public byte PacketCode => RootClientPacketCodeProvider.Cache<SaveProgramPacket>.Code;

    public int Size =>
        sizeof(int) + // ProgramId
        sizeof(bool) + // SaveAndRun
        Program.Sum(x => sizeof(ProgAction) + sizeof(byte) + x.Label.Length * 2 + sizeof(long)); // Program

    public int Encode(Span<byte> output)
    {
        var writer = output.Writer();
        writer.Write(ProgramId);
        writer.Write(SaveAndRun);
        foreach(var op in Program)
        {
            writer.Write(op.Operator);
            writer.WriteU1PrefixedUtf16(op.Label);
            writer.Write(op.Value);
        }
        return writer.Position;
    }

    public static SaveProgramPacket Decode(ReadOnlySpan<byte> input)
    {
        var reader = input.Reader();
        var id = reader.Read4();
        var sar = reader.Read<bool>();
        var prog = new List<(ProgAction, string, long)>();
        while (reader.CanRead)
            prog.Add((reader.Read<ProgAction>(), reader.ReadU1PrefixedUtf16(out _), reader.Read8()));
        return new(id, sar, prog);
    }

    public bool Equals(SaveProgramPacket other) =>
        ProgramId == other.ProgramId &&
        SaveAndRun == other.SaveAndRun &&
        Program.SequenceEqual(other.Program);
}
