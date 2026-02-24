using MinesServer.Networking.Exceptions;
using MinesServer.Utils;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MinesServer.Networking.Client.Packets.Actions;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct BuildCyanPacket() : IActionClientPacket<BuildCyanPacket>
{
    public byte PacketCode => ActionClientPacketCodeProvider.Cache<BuildCyanPacket>.Code;

    public int Size => Unsafe.SizeOf<BuildCyanPacket>();

    public int Encode(Span<byte> output) => output.UnsafeWrite(this);

    public static BuildCyanPacket Decode(ReadOnlySpan<byte> input) => input.UnsafeRead<BuildCyanPacket>();
}