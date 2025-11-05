
using Contentmanagement;
using GameObjects.repositories;
using MovmementService;
using Raylib_cs;
using System.Diagnostics;
using System.Numerics;

namespace GameObjects.objects;
public class Player : BaseGameEntity
{


    public Player(IMovement movementservice, float x, float y, float movementSpeed, int hitPoints, Texture2D texture2D)
        : base(movementservice, x, y, movementSpeed, hitPoints, texture2D, true)
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
                gameObjectRepository.AddEntity(new Bullet(new BulletMovement(), rotatepoint.X, rotatepoint.Y, Contentmanager.Instance.TexturesForTypes[new Tuple<Type, int>(typeof(Bullet), 1)], 10f, 0, Rotation));
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

    public override void Draw()
    {

        //Raylib.DrawTextureEx(Texture,new Vector2(X,Y),Rotation,1f,Color.White);
        if (ProtectectionLevel > 0)
        {
            Raylib.DrawCircleLines((int)X, (int)Y, 50, Color.Yellow);
        }


        Raylib.DrawTexturePro(Texture, new Rectangle(0, 0, Widht, Height), new Rectangle(X, Y, Widht, Height), new Vector2(Widht / 2, Height / 2), Rotation, Color.White);
        //var pos =RotatePoint(new Vector2(X +Widht/2 ,Y +Height/2 ),new Vector2(X,Y),Rotation);
        /* var pos = new Vector2
        {
            X = (X+25 - X) * cosTheta -  (Y+25 - Y) * sinTheta +(X - 25),
            Y = (Y+25 - Y) * sinTheta +(X+25 - X) * cosTheta +(Y -25)
        }; */

        //Raylib.DrawText(X.ToString(),200,200,5,Color.Red);
        //Raylib.DrawText(Y.ToString(),200,250,5,Color.Red);
        //Raylib.DrawText(angleInRadians.ToString(),200,350,5,Color.Red);
        //Raylib.DrawRectangle((int)pos.X,(int)pos.Y,(int)50,(int)50,Color.Red);
        //Raylib.DrawRectangle((int)CollisionRectangle.X,(int)CollisionRectangle.Y,(int)CollisionRectangle.Width,(int)CollisionRectangle.Height,Color.Beige);
    }

    public override void DrawInfo()
    {

        Raylib.DrawText($"Life energy: {HitPoints}", 20, 20, 20, Color.Gold);

        Raylib.DrawText($"Shield energy: {ProtectectionLevel}", 20, 40, 20, Color.Gold);


        Raylib.DrawText($"Enemies killed {KillCount}", 20, 60, 20, Color.Gold);

    }


}