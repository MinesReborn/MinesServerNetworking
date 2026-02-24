using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MinesServer.Networking.Client.Packets.Actions;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct BuildWhitePacket() : IActionClientPacket<BuildWhitePacket>
{
    public byte PacketCode => ActionClientPacketCodeProvider.Cache<BuildWhitePacket>.Code;

    public int Size => Unsafe.SizeOf<BuildWhitePacket>();

    public int Encode(Span<byte> output) => output.UnsafeWrite(this);

    public static BuildWhitePacket Decode(ReadOnlySpan<byte> input) => input.UnsafeRead<BuildWhitePacket>();
}
