using Asteroid_game.camera;
using Asteroid_game.drawing;
using GameObjects.repositories;
using MovmementService;
using Raylib_cs;

namespace GameObjects.objects;
/* 
Elk game object moet gebruik maken van de base game entity class
*/
public abstract class BaseGameEntity : IGameEntity
{

    protected IMovement MovementService;
    protected IDrawing Drawing;
    private int hitpointsAtStart;
    public BaseGameEntity(IMovement movementService, IDrawing drawing, float x, float y, float movementSpeed, int hitPoints, Texture2D texture2D, bool canShoot = false)
    {
        MovementService = movementService;
        X = x;
        Y = y;
        MovementSpeed = movementSpeed;
        HitPoints = hitPoints;
        IsMoving = true;
        Texture = texture2D;
        Widht = texture2D.Width;
        Height = texture2D.Height;
        IsAlive = true;
        hitpointsAtStart = hitPoints;
        CanShoot = canShoot;
        Drawing = drawing;
    }


    public BaseGameEntity(IMovement movementService, IDrawing drawing, float x, float y, int widht, int height, float movementSpeed, int hitPoints)
    {
        MovementService = movementService;
        Widht = widht;
        Height = height;
        X = x;
        Y = y;
        MovementSpeed = movementSpeed;
        HitPoints = hitPoints;
        IsMoving = true;
        IsAlive = true;
        hitpointsAtStart = hitPoints;
        Drawing = drawing;
    }

    public virtual void SetHitPoints(int hitPoints)
    {
        HitPoints = hitPoints;
        hitpointsAtStart = hitPoints;
    }
    public int HitPointsAtStart { get { return hitpointsAtStart; } }
    public Texture2D Texture { get; set; }
    public bool IsMoving { get; set; }
    public virtual Rectangle CollisionRectangle => new Rectangle(X, Y, Widht, Height);

    //public virtual Rectangle CollisionRectangle {
    //    get {
    //            float angleInRadians = Rotation * (MathF.PI / 180);
    //            float cosTheta = MathF.Cos(angleInRadians);
    //            float sinTheta = MathF.Sin(angleInRadians);
    //            var pos = new Vector2
    //            {
    //                X = (X+(Widht/2) - X) * cosTheta -  (Y+(Height/2) - Y) * sinTheta +(X - (Widht/2)),
    //                Y = (Y+(Height/2) - Y) * sinTheta +(X+(Widht/2) - X) * cosTheta +(Y -(Height/2))
    //            }; 
    //        return new Rectangle(pos.X,pos.Y,Widht,Height);
    //    }
    //}
    public float MovementSpeed { get; set; }
    public int Widht { get; set; }
    public int Height { get; set; }
    public float X { get; set; }
    public float Y { get; set; }
    public bool IsAlive { get; set; }

    public int HitPoints { get; set; }
    public int KillCount { get; set; }

    public void Move()
    {
        MovementService.Move(this);
    }


    public virtual void Draw(ICameraController cameraController)
    {
        Drawing.Drawing(this, cameraController);
    }

    public float Rotation { get; set; }
    public bool CanShoot { get; set; }
    public bool IsShooting { get; set; }

    public int ProtectectionLevel { get; set; }

    public int ShootingTime { get; set; }
    public int MaxElapsedMillisecondsShootingTime { get; set; }

    public virtual void Shoot(IGameObjectRepository gameObjectRepository) { }

    public virtual void TakeDamage(int damagePoints)
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