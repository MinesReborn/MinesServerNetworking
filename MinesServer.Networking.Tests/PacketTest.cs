namespace MinesServer.Networking.Tests;

internal abstract class PacketTest<TPacket> where TPacket : INetworkPacket<TPacket>
{
    public abstract TPacket Packet { get; }

    [Test]
    public virtual void LengthPrediction()
    {
        var packet = Packet;
        Span<byte> encoded = stackalloc byte[packet.Size];
        var len = packet.Encode(encoded);
        if(packet is IUnreliableLengthPacket)
            Assert.That(len, Is.LessThanOrEqualTo(packet.Size));
        else
            Assert.That(len, Is.EqualTo(packet.Size));
    }

    [Test]
    public virtual void Encoding()
    {
        var packet = Packet;
        Span<byte> encoded = stackalloc byte[packet.Size];
        _ = packet.Encode(encoded);
        var pack = TPacket.Decode(encoded);
        Assert.That(pack, Is.EqualTo(packet));
        Span<byte> re_encoded = stackalloc byte[pack.Size];
        _ = pack.Encode(re_encoded);
        Assert.That(encoded.ToArray(), Is.EquivalentTo(re_encoded.ToArray()));
    }
}
