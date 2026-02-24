using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MinesServer.Networking.Client.Packets.Programmator;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct PauseProgramPacket() : IRootClientPacket<PauseProgramPacket>
{
    public byte PacketCode => RootClientPacketCodeProvider.Cache<PauseProgramPacket>.Code;

    public int Size => Unsafe.SizeOf<PauseProgramPacket>();

    public int Encode(Span<byte> output) => output.UnsafeWrite(this);

    public static PauseProgramPacket Decode(ReadOnlySpan<byte> input) => input.UnsafeRead<PauseProgramPacket>();
}
