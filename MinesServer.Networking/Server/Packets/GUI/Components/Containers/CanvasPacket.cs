using MinesServer.Utils;

namespace MinesServer.Networking.Server.Packets.GUI.Components.Containers;

public record class CanvasPacket : ContainerComponentPacket, IGUIComponentPacket<CanvasPacket>
{
    public override byte PacketCode => GUIComponentPacketCodeProvider.Cache<CanvasPacket>.Code;

    public static CanvasPacket Decode(ReadOnlySpan<byte> input)
    {
        var reader = input.Reader();
        return new(ref reader);
    }

    protected CanvasPacket(ref MemoryReader reader) : base(ref reader) { }

    public CanvasPacket() : base() { }
}