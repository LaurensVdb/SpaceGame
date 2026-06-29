using System.Numerics;
using Behavior.Shooting;
using Drawing;
using GameObjects.Objects;
using Behavior.Movement;
using Raylib_cs;

namespace GameObjects.Objects;

public class Player : ShootableEntity, IMovableEntity
{
    private readonly IMovement movementService;
    public Player(IMovement movementservice, IDrawing drawing, IShooting shooting, float x, float y, float movementSpeed, int hitPoints, Texture2D texture2D)
        : base(drawing, shooting, x, y, movementSpeed, hitPoints, texture2D)
    {
        ProtectectionLevel = 0;
        movementService = movementservice;
    }

    private Vector2 RotatePoint(Vector2 pointToRotate, Vector2 centerPoint, float angleInDegrees)
    {
        float angleInRadians = angleInDegrees * (MathF.PI / 180);
        float cosTheta = MathF.Cos(angleInRadians);
        float sinTheta = MathF.Sin(angleInRadians);
        return new Vector2
        {
            X = cosTheta * (pointToRotate.X - centerPoint.X) - sinTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.X,
            Y = sinTheta * (pointToRotate.X - centerPoint.X) + cosTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.Y
        };
    }
    public override Rectangle CollisionRectangle => new Rectangle(X - (Widht / 2), Y - (Height / 2), Widht, Height);

    public override Bullet? Shoot()
    {
        var rotatepoint = RotatePoint(new Vector2(X, Y), new Vector2(X, Y), Rotation);
        return ShootingService.Shooting(rotatepoint, Rotation);
    }

    public void Move()
    {
        this.movementService.Move(this);
    }
}