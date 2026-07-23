using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MinesServer.Networking.Client.Packets.Programmator;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct StopProgramPacket() : IRootClientPacket<StopProgramPacket>
{
    public byte PacketCode => RootClientPacketCodeProvider.Cache<StopProgramPacket>.Code;

    public int Size => Unsafe.SizeOf<StopProgramPacket>();

    public int Encode(Span<byte> output) => output.UnsafeWrite(this);

    public static StopProgramPacket Decode(ReadOnlySpan<byte> input) => input.UnsafeRead<StopProgramPacket>();
}
