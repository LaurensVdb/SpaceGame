using System.Diagnostics;
using System.Numerics;
using Raylib_cs;
namespace GameObjects;



public class Enemy : BaseGameEntity
{

    private Stopwatch timer;

    protected override Rectangle CollisionRectangle => new Rectangle(X, Y, Widht, Height);

    public Enemy(float x, float y, float movementSpeed, int hitPoints, Texture2D texture2D, bool canShoot = false) : base(x, y, movementSpeed, hitPoints, texture2D, canShoot)
    {

        timer = new Stopwatch();
        timer.Start();
    }
    public override void Draw()
    {

        //Raylib.DrawCircleGradient((int)X, (int)Y,Widht, Color.Black, Color.DarkBlue);
        if (IsAlive)
        {
            int newWidth = Widht / HitPointsAtStart;
            Raylib.DrawRectangle((int)X, (int)Y - 10, newWidth * HitPoints, 5, Color.Gold);
            Raylib.DrawTextureV(Texture, new Vector2(X, Y), Color.White);

        }

        //Raylib.DrawRectangle((int)CollisionRectangle.X-Widht,(int)CollisionRectangle.Y-Widht,(int)CollisionRectangle.Width*2,(int)CollisionRectangle.Height*2,Color.Red);
    }


    public override void Move(int targetX, int targetY)
    {
        if (IsMoving)
        {
            if (X <= targetX)
            {
                X += MovementSpeed;
            }
            if (X >= targetX)
            {
                X -= MovementSpeed;
            }
            if (Y <= targetY)
            {
                Y += MovementSpeed;
            }
            if (Y >= targetY)
            {
                Y -= MovementSpeed;
            }
        }
    }


    public override void Shoot(IGameObjectRepository gameObjectRepository)
    {
        var deltaX = gameObjectRepository.Player.X - X;
        var deltaY = gameObjectRepository.Player.Y - Y;
        var playerrotation = MathF.Atan2(deltaY, deltaX) * (180f / MathF.PI) + 90;
        if (timer.ElapsedMilliseconds >= 2000)
        {
            timer.Reset();
            gameObjectRepository.AddEntity(new Bullet(X, Y, 5, 5, 10f, 0, playerrotation, true));
            timer.Start();
        }

    }

    public override bool IsCollision(BaseGameEntity entityCollisionCheck)
    {
        var isCollision = base.IsCollision(entityCollisionCheck);
        switch (entityCollisionCheck)
        {


            case Enemy i:
                {
                    if (isCollision)
                    {
                        if (X <= entityCollisionCheck.X)
                        {
                            X -= MovementSpeed;
                            entityCollisionCheck.X += MovementSpeed;
                        }
                        if (X >= entityCollisionCheck.X)
                        {
                            X += MovementSpeed;
                            entityCollisionCheck.X -= MovementSpeed;
                        }
                        if (Y <= entityCollisionCheck.Y)
                        {
                            Y -= MovementSpeed;
                            entityCollisionCheck.Y += MovementSpeed;
                        }
                        if (Y >= entityCollisionCheck.Y)
                        {
                            Y += MovementSpeed;
                            entityCollisionCheck.Y -= MovementSpeed;
                        }
                    }
                    break;
                }
            case Player i:
                {
                    if (isCollision && IsAlive)
                    {
                        i.TakeDamage(1);
                        IsAlive = false;
                    }
                    break;
                }
        }

        return isCollision;
    }



}