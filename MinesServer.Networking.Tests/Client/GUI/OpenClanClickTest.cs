using MinesServer.Networking.Client.Packets.GUI;

namespace MinesServer.Networking.Tests.Client.GUI;

internal class OpenClanClickTest : RootClientPacketTest<OpenClanClickPacket>
{
    public override OpenClanClickPacket Packet => new();
}

