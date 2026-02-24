using MinesServer.Networking.Client.Packets.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesServer.Networking.Tests.Client.Inventory;

internal class DeselectItemTest : RootClientPacketTest<DeselectItemPacket>
{
    public override DeselectItemPacket Packet => new();
}