using MinesServer.Networking.Client.Packets.Chat;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesServer.Networking.Tests.Client.Chat;

internal class ChangeChatColorTest : RootClientPacketTest<ChangeChatColorPacket>
{
    public override ChangeChatColorPacket Packet => new(Color.FromArgb(255, 128, 64, 255));
}

