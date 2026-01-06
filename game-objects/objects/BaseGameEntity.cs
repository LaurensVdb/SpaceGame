using Asteroid_game.camera;
using Asteroid_game.drawing;
using GameObjects.repositories;
using MovmementService;
using Raylib_cs;

namespace GameObjects.objects;
/* 
Elk game object moet gebruik maken van de base game entity class
*/
public abstract class BaseGameEntity
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

    public virtual void SetHitPoints(int hitPoints)
    {
        HitPoints = hitPoints;
        hitpointsAtStart = hitPoints;
    }

    public Texture2D Texture { get; set; }

    public virtual Rectangle CollisionRectangle => new Rectangle(X, Y, Widht, Height);
    public bool IsMoving { get; set; }
    public float MovementSpeed { get; set; }
    public int Widht { get; set; }
    public int Height { get; set; }
    public float X { get; set; }
    public float Y { get; set; }
    public bool IsAlive { get; set; }
    public int HitPointsAtStart { get { return hitpointsAtStart; } }

    public int HitPoints { get; set; }
    public int KillCount { get; set; }

    public float Rotation { get; set; }


    public int ProtectectionLevel { get; set; }

    public bool CanShoot { get; set; }

    public int MaxElapsedMillisecondsShootingTime { get; set; }

    public void Move()
    {
        MovementService.Move(this);
    }


    public virtual void Draw(ICameraController cameraController)
    {
        Drawing.Drawing(this, cameraController);
    }



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