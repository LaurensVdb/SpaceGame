using Camera;
using Drawing;
using Behavior.Movement;
using Raylib_cs;

namespace GameObjects.Objects;
/* 
Elk game object moet gebruik maken van de base game entity class
*/
public abstract class BaseGameEntity
{
    private int hitpointsAtStart;
    public BaseGameEntity(float x, float y, float movementSpeed,
    int hitPoints, Texture2D texture2D)
    {
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