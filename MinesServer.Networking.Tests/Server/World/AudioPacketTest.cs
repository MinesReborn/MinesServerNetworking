using MinesServer.Networking.Server.Packets.World;

namespace MinesServer.Networking.Tests.Server.World;

internal class AudioPacketTest : PacketTest<AudioPacket>
{
    public override AudioPacket Packet => new(
        Data.SFX.Boom,
        303,
        50,
        60,
        [
            new("clr", "F00"),
            new("radius", "15")
        ]);
}