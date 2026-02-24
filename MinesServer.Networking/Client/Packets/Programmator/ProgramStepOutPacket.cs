using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MinesServer.Networking.Client.Packets.Programmator;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct ProgramStepOutPacket() : IRootClientPacket<ProgramStepOutPacket>
{
    public byte PacketCode => RootClientPacketCodeProvider.Cache<ProgramStepOutPacket>.Code;

    public int Size => Unsafe.SizeOf<ProgramStepOutPacket>();

    public int Encode(Span<byte> output) => output.UnsafeWrite(this);

    public static ProgramStepOutPacket Decode(ReadOnlySpan<byte> input) => input.UnsafeRead<ProgramStepOutPacket>();
}
