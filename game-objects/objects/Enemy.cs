using Behavior.Shooting;
using Drawing;
using GameObjects.Objects;
using Behavior.Movement;
using Raylib_cs;
using System.Numerics;

namespace GameObjects.Objects;



public class Enemy : ShootableEntity, IMovableEntity
{
    //public override Rectangle CollisionRectangle => new Rectangle(X, Y, Widht, Height);
    private readonly Player _player;
    private readonly IMovement movementService;

    public Player TargetPlayer { get { return _player; } }
    public Enemy(IMovement movementservice, IDrawing drawing, IShooting shooting, Player player, float x, float y, float movementSpeed, int hitPoints, Texture2D texture2D)
    : base(drawing, shooting, x, y, movementSpeed, hitPoints, texture2D)
    {
        _player = player;
        movementService = movementservice;
    }


    public void SetShootingStrategy(IShooting shooting)
    {
        ShootingService = shooting;
    }
    public override Bullet? Shoot()
    {
        var deltaX = _player.X - X;
        var deltaY = _player.Y - Y;
        var playerrotation = MathF.Atan2(deltaY, deltaX) * (180f / MathF.PI) + 90;

        var position = new Vector2(X, Y);
        return ShootingService.Shooting(position, playerrotation);
    }

    public void Move()
    {
        movementService.Move(this);
    }
}