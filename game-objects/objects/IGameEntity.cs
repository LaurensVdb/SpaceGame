using GameObjects.repositories;
using Raylib_cs;

namespace GameObjects.objects; 

public interface IGameEntity{
    int HitPointsAtStart { get;}
    Texture2D Texture { get; set; }
    bool IsMoving { get; set; }
    //protected virtual Rectangle CollisionRectangle => new Rectangle(X,Y,Widht,Height);
    Rectangle CollisionRectangle{get => new Rectangle(X,Y,Widht,Height);}
    float MovementSpeed { get; set; }
    int Widht { get; set; }
    int Height { get; set; }
    float X { get; set; }
    float Y { get; set; }
    bool IsAlive { get; set; }
    
    int HitPoints { get; set; }
    int KillCount { get; set; }

    virtual void Move(){}
    virtual void Move(int targetX,int targetY){}
    abstract void Draw(); 
    virtual void DrawInfo(){}
    
    float Rotation { get; set; }
    bool CanShoot { get; set; }
    bool IsShooting  { get; set; }
    bool IsCollision(IGameEntity entityCollisionCheck); 
    
    void Shoot(IGameObjectRepository gameObjectRepository);

    void TakeDamage(int damagePoints);
}