using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MinesServer.Networking.Client.Packets.Programmator;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct ProgramStepInPacket() : IRootClientPacket<ProgramStepInPacket>
{
    public byte PacketCode => RootClientPacketCodeProvider.Cache<ProgramStepInPacket>.Code;

    public int Size => Unsafe.SizeOf<ProgramStepInPacket>();

    public int Encode(Span<byte> output) => output.UnsafeWrite(this);

    public static ProgramStepInPacket Decode(ReadOnlySpan<byte> input) => input.UnsafeRead<ProgramStepInPacket>();
}
