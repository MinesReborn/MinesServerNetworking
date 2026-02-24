using MinesServer.Networking.Server.Packets.GUI.Components.Visual;

namespace MinesServer.Networking.Tests.Server.GUI.Visual;

internal class PanelTest : PacketTest<PanelPacket>
{
    public override PanelPacket Packet => new();
}