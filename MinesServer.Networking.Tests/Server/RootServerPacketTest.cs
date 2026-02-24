using MinesServer.Networking.Server;
using MinesServer.Networking.Server.Packets;

namespace MinesServer.Networking.Tests.Server;

internal abstract class RootServerPacketTest<TPacket> : PacketTest<TPacket> where TPacket : IRootServerPacket<TPacket>
{
    [Test]
    public virtual void WrappedEncoding()
    {
        var packet = new ServerPacket(Packet);
        Span<byte> encoded = stackalloc byte[packet.Size];
        _ = packet.Encode(encoded);
        var pack = ServerPacket.Decode(encoded);
        Assert.That(pack, Is.EqualTo(packet));
        Span<byte> re_encoded = stackalloc byte[pack.Size];
        _ = pack.Encode(re_encoded);
        Assert.That(encoded.ToArray(), Is.EquivalentTo(re_encoded.ToArray()));
    }
}
