using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MinesServer.Networking.Client.Packets.GUI;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct OpenHelpClickPacket() : IRootClientPacket<OpenHelpClickPacket>
{
    public byte PacketCode => RootClientPacketCodeProvider.Cache<OpenHelpClickPacket>.Code;

    public int Size => Unsafe.SizeOf<OpenHelpClickPacket>();

    public int Encode(Span<byte> output) => output.UnsafeWrite(this);

    public static OpenHelpClickPacket Decode(ReadOnlySpan<byte> input) => input.UnsafeRead<OpenHelpClickPacket>();
}