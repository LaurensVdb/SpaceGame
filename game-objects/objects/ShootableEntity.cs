using Behavior.Shooting;
using Drawing;
using GameObjects.Objects;
using Behavior.Movement;
using Raylib_cs;

namespace GameObjects.Objects;

public abstract class ShootableEntity : BaseGameEntity
{
    public IShooting ShootingService;
    public ShootableEntity(IDrawing drawing, IShooting shootingService, float x, float y, float movementSpeed, int hitPoints, Texture2D texture2D)
    : base(drawing, x, y, movementSpeed, hitPoints, texture2D)
    {
        ShootingService = shootingService;
    }

    public abstract Bullet? Shoot();
}
