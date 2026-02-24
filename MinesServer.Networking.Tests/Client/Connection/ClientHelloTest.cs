using MinesServer.Networking.Client.Packets.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesServer.Networking.Tests.Client.Connection;

internal class ClientHelloTest : RootClientPacketTest<ClientHelloPacket>
{
    public override ClientHelloPacket Packet => new(
        321,
        "Windows",
        11,
        "00112233445566778899AABBCCDDEEFF",
        "m3.a.2C69E5FD-AD4C-4EFE-8449-58B4844E4D9F");
}
