using MinesServer.Networking.Server.Packets.Connection;

namespace MinesServer.Networking.Tests.Server.Connection;

internal class AuthTokenPacketTest : RootServerPacketTest<AuthTokenPacket>
{
    public override AuthTokenPacket Packet => new("test-auth-token");
}
