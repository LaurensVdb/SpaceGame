using System.Numerics;
using Asteroid_game.behavior.shooting;
using Asteroid_game.drawing;
using Asteroid_game.game_objects.objects;
using MovmementService;
using Raylib_cs;

namespace GameObjects.objects;

public class Player : ShootableEntity
{
    public Player(IMovement movementservice, IDrawing drawing, IShooting shooting, float x, float y, float movementSpeed, int hitPoints, Texture2D texture2D)
        : base(movementservice, drawing, shooting, x, y, movementSpeed, hitPoints, texture2D)
    {
        ProtectectionLevel = 0;
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
        return ShootingService.Shooting(rotatepoint,Rotation);
    }
}