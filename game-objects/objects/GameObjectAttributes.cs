using Raylib_cs;

namespace GameObjects.Objects;

public record GameObjectAttributes(
    float X,
    float Y,
    float MovementSpeed,
    int HitPoints,
    Texture2D Texture);
