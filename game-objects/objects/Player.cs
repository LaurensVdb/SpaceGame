using Asteroid_game.drawing;
using Contentmanagement;
using GameObjects.repositories;
using MovmementService;
using Raylib_cs;
using System.Diagnostics;
using System.Numerics;

namespace GameObjects.objects;

public class Player : BaseGameEntity
{
    public Player(IMovement movementservice, IDrawing drawing, float x, float y, float movementSpeed, int hitPoints, Texture2D texture2D)
        : base(movementservice, drawing, x, y, movementSpeed, hitPoints, texture2D, true)
    {
        ProtectectionLevel = 0;
        MaxElapsedMillisecondsShootingTime = 100;
    }

    public override Rectangle CollisionRectangle => new Rectangle(X - (Widht / 2), Y - (Height / 2), Widht, Height);

    Stopwatch shootTimer = new Stopwatch();
    public override void Shoot(IGameObjectRepository gameObjectRepository)
    {
        shootTimer.Start();

        if (Raylib.IsMouseButtonDown(MouseButton.Left))
        {
            //schiet
            if (shootTimer.ElapsedMilliseconds > MaxElapsedMillisecondsShootingTime)
            {
                var rotatepoint = RotatePoint(new Vector2(X, Y), new Vector2(X, Y), Rotation);
                gameObjectRepository.AddEntity(new Bullet(new BulletMovement(), new BulletDrawing(), rotatepoint.X, rotatepoint.Y, Contentmanager.Instance.TexturesForTypes[new Tuple<Type, int>(typeof(Bullet), 1)], 10f, 0, Rotation));
                shootTimer.Reset();
            }

        }

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

}