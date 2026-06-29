using Behavior.Shooting;
using Drawing;
using GameObjects.Objects;
using Behavior.Movement;
using Raylib_cs;

namespace GameObjects.Objects;

public abstract class ShootableEntity : BaseGameEntity
{
    public IShooting ShootingService;
    public ShootableEntity(IShooting shootingService, float x, float y, float movementSpeed, Texture2D texture2D)
    : base(x, y, movementSpeed, texture2D)
    {
        ShootingService = shootingService;
    }

    public abstract Bullet? Shoot();
}
