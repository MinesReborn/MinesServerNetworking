namespace MinesServer.Networking.Server.Packets.Connection;

public enum CellRenderLayer : byte
{
    WorldBoundary = 0, // Отдельный слой для оформления границы игровой области.
    Underlay = 1, // Подложка под основным слоем; например, Empty.
    Foreground = 2, // Передний план; например, Rock.
    Background = 3 // Фон; например, BuildingRoad.
}
