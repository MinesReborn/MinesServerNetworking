using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MinesServer.Networking.Client.Packets.GUI;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct OpenClanClickPacket() : IRootClientPacket<OpenClanClickPacket>
{
    public byte PacketCode => RootClientPacketCodeProvider.Cache<OpenClanClickPacket>.Code;

    public int Size => Unsafe.SizeOf<OpenClanClickPacket>();

    public int Encode(Span<byte> output) => output.UnsafeWrite(this);

    public static OpenClanClickPacket Decode(ReadOnlySpan<byte> input) => input.UnsafeRead<OpenClanClickPacket>();
}
