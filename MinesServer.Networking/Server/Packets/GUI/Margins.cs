using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MinesServer.Networking.Server.Packets.GUI;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct Margins(byte Top, byte Left, byte Bottom, byte Right) : IServerPacket<Margins>
{
    public int Size => Unsafe.SizeOf<Margins>();

    public int Encode(Span<byte> output) => output.UnsafeWrite(this);

    public static Margins Decode(ReadOnlySpan<byte> input) => input.UnsafeRead<Margins>();
}
