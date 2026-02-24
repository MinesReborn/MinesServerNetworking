namespace MinesServer.Data;

public enum SFX : byte
{
    Bz,
    Death,
    BombTick,
    Boom,
    Destroy,
    Dizz,
    EMI,
    Geology,
    Geopack,
    TpIn,
    TpOut,
    NoHp,
    NoHpSmall,
    Smoke,
    Volcano,
    C190,
    Crystal,
    Pull, // Animates a sprite from the player to a point in the world
    Push, // Animates a sprite from a point in the world to the player
    Heal,
    Hurt,
    GunShot,
    Music, // Plays music
    Alarm // Programmator sound
}
