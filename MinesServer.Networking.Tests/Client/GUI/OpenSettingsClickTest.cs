using MinesServer.Networking.Client.Packets.GUI;

namespace MinesServer.Networking.Tests.Client.GUI;

internal class OpenSettingsClickTest : RootClientPacketTest<OpenSettingsClickPacket>
{
    public override OpenSettingsClickPacket Packet => new();
}

