using System.Numerics;
using Raylib_cs;
using GameObjects.repositories;

namespace GameObjects.objects;
/* 
Elk game object moet gebruik maken van de base game entity class
*/
public abstract class BaseGameEntity : IGameEntity{

 public BaseGameEntity(float x, float y,float movementSpeed,int hitPoints,Texture2D texture2D,bool canShoot=false)
    {
      
        X=x;
        Y=y;
        MovementSpeed=movementSpeed;
        HitPoints=hitPoints;
        IsMoving=true;
        Texture = texture2D;
        Widht = texture2D.Width;
        Height =texture2D.Height;
        IsAlive=true;
        hitpointsAtStart= hitPoints;
        CanShoot = canShoot;
    }

    private int hitpointsAtStart;
    public BaseGameEntity(float x, float y, int widht, int height,float movementSpeed,int hitPoints)
    {
        Widht = widht ; 
        Height = height; 
        X=x;
        Y=y;
        MovementSpeed=movementSpeed;
        HitPoints=hitPoints;
        IsMoving=true;
        IsAlive=true;
        hitpointsAtStart= hitPoints;
    }

    public virtual void SetHitPoints(int hitPoints){
        HitPoints = hitPoints;
        hitpointsAtStart = hitPoints;
    }
    public int HitPointsAtStart { get{return hitpointsAtStart;} }
    public Texture2D Texture { get; set; }
    public bool IsMoving { get; set; }
    //protected virtual Rectangle CollisionRectangle => new Rectangle(X,Y,Widht,Height);

    public virtual Rectangle CollisionRectangle {
        get {
                float angleInRadians = Rotation * (MathF.PI / 180);
                float cosTheta = MathF.Cos(angleInRadians);
                float sinTheta = MathF.Sin(angleInRadians);
                var pos = new Vector2
                {
                    X = (X+(Widht/2) - X) * cosTheta -  (Y+(Height/2) - Y) * sinTheta +(X - (Widht/2)),
                    Y = (Y+(Height/2) - Y) * sinTheta +(X+(Widht/2) - X) * cosTheta +(Y -(Height/2))
                }; 
            return new Rectangle(pos.X,pos.Y,Widht,Height);
        }
    }
    public float MovementSpeed { get; set; }
    public int Widht { get; set; }
    public int Height { get; set; }
    public float X { get; set; }
    public float Y { get; set; }
    public bool IsAlive { get; set; }
    
    public int HitPoints { get; set; }
    public int KillCount { get; set; }

    public virtual void Move(){}
    public virtual void Move(int targetX,int targetY){}
    public abstract void Draw(); 
    public virtual void DrawInfo(){}
    
    public float Rotation { get; set; }
    public bool CanShoot { get; set; }
    public bool IsShooting  { get; set; }



    public virtual bool IsCollision(IGameEntity entityCollisionCheck){

        return Raylib.CheckCollisionRecs(CollisionRectangle,entityCollisionCheck.CollisionRectangle);
    } 
    
    public virtual void Shoot(IGameObjectRepository gameObjectRepository){}

    public virtual void TakeDamage(int damagePoints){
        HitPoints-=damagePoints; 
        if(HitPoints<=0){
            IsAlive=false;
        }
    }


}