using MinesServer.Networking.Client.Packets.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesServer.Networking.Tests.Client.GUI;

internal class ElementClickTest : RootClientPacketTest<ElementClickPacket>
{
    public override ElementClickPacket Packet => new(
        "TestWindow",
        42,
        [
            new("key1", "value1"),
            new("anotherKey", "anotherValue with unicode: проверка")
        ]);
}

