namespace MinesServer.Networking.Server.Packets.Connection;

public enum CellOutlineKind : byte
{
    Rigid = 0, // Жёсткий контур; не изгибается вслед за соседними клетками.
    Wavy = 1, // Волнистый контур; например, у WorldEdge.
    Round = 2, // Скруглённый контур; например, у Lava.
    Pliant = 3, // Податливый контур; узлы могут смещаться вслед за соседним Wavy.
    Wall = 4, // Контур стены; используется BuildingWall.
    Corner = 5, // Контур угла; используется BuildingCorner.
    Door = 6 // Контур двери; используется BuildingDoor.
}
