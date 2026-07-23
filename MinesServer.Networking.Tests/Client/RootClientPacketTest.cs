using MinesServer.Networking.Client;
using MinesServer.Networking.Client.Packets;

namespace MinesServer.Networking.Tests.Client;

internal abstract class RootClientPacketTest<TPacket> : PacketTest<TPacket> where TPacket : IRootClientPacket<TPacket>
{
    [Test]
    public virtual void WrappedEncoding()
    {
        var packet = new ClientPacket((uint)DateTime.UtcNow.Ticks, Packet);
        Span<byte> encoded = stackalloc byte[packet.Size];
        _ = packet.Encode(encoded);
        var pack = ClientPacket.Decode(encoded);
        Assert.That(pack, Is.EqualTo(packet));
        Span<byte> re_encoded = stackalloc byte[pack.Size];
        _ = pack.Encode(re_encoded);
        Assert.That(re_encoded.ToArray(), Is.EquivalentTo(encoded.ToArray()));
    }
}
