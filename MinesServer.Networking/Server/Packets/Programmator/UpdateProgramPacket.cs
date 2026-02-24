using MinesServer.Data;
using MinesServer.Utils;
using System;
using System.Linq;
using System.Collections.Generic;

namespace MinesServer.Networking.Server.Packets.Programmator;

public readonly record struct UpdateProgramPacket(int ProgramId, IReadOnlyList<(ProgAction Operator, string Label, int Value)> Instructions) : IRootServerPacket<UpdateProgramPacket>
{
    public ushort PacketCode => RootServerPacketCodeProvider.Cache<UpdateProgramPacket>.Code;

    public int Size =>
        sizeof(int) + // ProgramId
        Instructions.Sum(x => sizeof(ProgAction) + sizeof(int) + sizeof(byte) + x.Label.Length * 2); // Instructions

    public int Encode(Span<byte> output)
    {
        var writer = output.Writer();
        writer.Write(ProgramId);
        foreach(var instruction in Instructions)
        {
            writer.Write(instruction.Operator);
            writer.WriteU1PrefixedUtf16(instruction.Label);
            writer.Write(instruction.Value);
        }
        return writer.Position;
    }

    public static UpdateProgramPacket Decode(ReadOnlySpan<byte> input)
    {
        var reader = input.Reader();
        var progId = reader.Read4();
        List<(ProgAction Operator, string Label, int Value)> instructions = new();
        while(reader.CanRead)
            instructions.Add((reader.Read<ProgAction>(), reader.ReadU1PrefixedUtf16(out _), reader.Read4()));
        return new(progId, instructions);
    }

    public bool Equals(UpdateProgramPacket other) =>
        ProgramId == other.ProgramId &&
        Instructions.SequenceEqual(other.Instructions);
}
