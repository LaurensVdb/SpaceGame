using Asteroid_game.camera;
using GameObjects.repositories;
using Raylib_cs;

namespace GameObjects.objects;

public interface IGameEntity
{
    int HitPointsAtStart { get; }
    Texture2D Texture { get; set; }
    bool IsMoving { get; set; }
    //protected virtual Rectangle CollisionRectangle => new Rectangle(X,Y,Widht,Height);
    Rectangle CollisionRectangle { get => new Rectangle(X, Y, Widht, Height); }
    float MovementSpeed { get; set; }
    int Widht { get; set; }
    int Height { get; set; }
    float X { get; set; }
    float Y { get; set; }
    bool IsAlive { get; set; }

    int HitPoints { get; set; }
    int KillCount { get; set; }

    void Move() { }
    virtual void DrawInfo() { }

    float Rotation { get; set; }
    bool CanShoot { get; set; }
    bool IsShooting { get; set; }

    int MaxElapsedMillisecondsShootingTime { get; set; }

    void Shoot(IGameObjectRepository gameObjectRepository);

    void TakeDamage(int damagePoints);
    void Draw(ICameraController cameraController);

    int ProtectectionLevel { get; set; }
}