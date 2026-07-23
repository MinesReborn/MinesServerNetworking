using MinesServer.Utils;
using System;

namespace MinesServer.Networking.Server.Packets.Programmator;

public readonly record struct BreakpointHitPacket(int[] CallStack) : IRootServerPacket<BreakpointHitPacket>
{
    public ushort PacketCode => RootServerPacketCodeProvider.Cache<BreakpointHitPacket>.Code;

    public int Size =>
        sizeof(int) * CallStack.Length; // CallStack

    public int Encode(Span<byte> output)
    {
        var writer = output.Writer();
        writer.WriteArray(CallStack);
        return writer.Position;
    }

    public static BreakpointHitPacket Decode(ReadOnlySpan<byte> input) => new(input.Reader().ReadRemainingAsArray<int>());

    public bool Equals(BreakpointHitPacket other) => CallStack.SequenceEqual(other.CallStack);
}
