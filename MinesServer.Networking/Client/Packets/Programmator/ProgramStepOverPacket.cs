using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MinesServer.Networking.Client.Packets.Programmator;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct ProgramStepOverPacket() : IRootClientPacket<ProgramStepOverPacket>
{
    public byte PacketCode => RootClientPacketCodeProvider.Cache<ProgramStepOverPacket>.Code;

    public int Size => Unsafe.SizeOf<ProgramStepOverPacket>();

    public int Encode(Span<byte> output) => output.UnsafeWrite(this);

    public static ProgramStepOverPacket Decode(ReadOnlySpan<byte> input) => input.UnsafeRead<ProgramStepOverPacket>();
}
