using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MinesServer.Networking.Client.Packets.GUI;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct OpenSettingsClickPacket() : IRootClientPacket<OpenSettingsClickPacket>
{
    public byte PacketCode => RootClientPacketCodeProvider.Cache<OpenSettingsClickPacket>.Code;

    public int Size => Unsafe.SizeOf<OpenSettingsClickPacket>();

    public int Encode(Span<byte> output) => output.UnsafeWrite(this);

    public static OpenSettingsClickPacket Decode(ReadOnlySpan<byte> input) => input.UnsafeRead<OpenSettingsClickPacket>();
}
