namespace MinesServer.Networking.Server.Packets.World;

public class HBPacketCodeProvider : NetworkPacketCodeProvider<IHBPacket, byte, HBPacketCodeProvider>
{
    static HBPacketCodeProvider()
    {
        Register<MapRegionPacket>();
        Register<PackPacket>();
        Register<RobotPositionPacket>();
        Register<AudioPacket>();
        Register<RemovePackPacket>();
    }
}
