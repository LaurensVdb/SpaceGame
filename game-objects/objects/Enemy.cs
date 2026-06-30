using Behavior.Shooting;
using Drawing;
using GameObjects.Objects;
using Behavior.Movement;
using Raylib_cs;
using System.Numerics;
using Camera;

namespace GameObjects.Objects;



public class Enemy : ShootableEntity, IMovableEntity, IDrawableEntity, IDamageableEntity
{
    //public override Rectangle CollisionRectangle => new Rectangle(X, Y, Widht, Height);
    private readonly Player _player;
    private readonly IMovement movementService;
    private readonly IDrawing drawing;

    public Player TargetPlayer { get { return _player; } }

    public int ProtectectionLevel { get; set; }
    public int HitPointsAtStart
    {
        get;
        set
        {
            field = value;
            HitPoints = value;
        }
    }

    public bool IsMoving { get; set; }
    public float MovementSpeed { get; set; }
    public int HitPoints { get; set; }
    public Enemy(IMovement movementservice, IDrawing drawing, IShooting shooting, Player player, float x, float y, Texture2D texture2D)
    : base(shooting, x, y, texture2D)
    {
        _player = player;
        movementService = movementservice;
        this.drawing = drawing;
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

    public void Draw(ICameraController cameraController)
    {
        this.drawing.Drawing(this, cameraController);
    }

    public void TakeDamage(int damagePoints)
    {

        if (ProtectectionLevel <= 0)
        {
            HitPoints -= damagePoints;
        }
        else
        {
            ProtectectionLevel--;
        }

        if (HitPoints <= 0)
        {
            IsAlive = false;
        }
    }


}