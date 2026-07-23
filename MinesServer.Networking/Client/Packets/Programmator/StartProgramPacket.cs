using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MinesServer.Networking.Client.Packets.Programmator;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct StartProgramPacket() : IRootClientPacket<StartProgramPacket>
{
    public byte PacketCode => RootClientPacketCodeProvider.Cache<StartProgramPacket>.Code;

    public int Size => Unsafe.SizeOf<StartProgramPacket>();

    public int Encode(Span<byte> output) => output.UnsafeWrite(this);

    public static StartProgramPacket Decode(ReadOnlySpan<byte> input) => input.UnsafeRead<StartProgramPacket>();
}
