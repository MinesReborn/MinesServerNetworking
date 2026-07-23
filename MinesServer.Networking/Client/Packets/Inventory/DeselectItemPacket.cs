using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MinesServer.Networking.Client.Packets.Inventory;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct DeselectItemPacket() : IRootClientPacket<DeselectItemPacket>
{
    public byte PacketCode => RootClientPacketCodeProvider.Cache<DeselectItemPacket>.Code;

    public int Size => Unsafe.SizeOf<DeselectItemPacket>();

    public int Encode(Span<byte> output) => output.UnsafeWrite(this);

    public static DeselectItemPacket Decode(ReadOnlySpan<byte> input) => input.UnsafeRead<DeselectItemPacket>();
}
