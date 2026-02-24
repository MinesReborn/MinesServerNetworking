using MinesServer.Networking.Server.Packets.Information;

namespace MinesServer.Networking.Tests.Server.Information;

internal class SoundConfigTest : PacketTest<SoundConfigPacket>
{
    public override SoundConfigPacket Packet => new(80, new Dictionary<string, byte>
    {
        { "ambient", 90 },
        { "ui_click", 40 }
    });
}