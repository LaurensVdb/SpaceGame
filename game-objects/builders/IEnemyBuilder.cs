using System.Numerics;
using ContentManagement;
using GameObjects.Objects;
using Raylib_cs;

public interface IEnemyBuilder
{
    public void SetTexture(Texture2D texture2D);
    public void SetPosition(float x, float y);
    void CanShoot(int shootingTime);
    void SetHitpoints(int hitPoints);

    void IsMovable(bool isMoving);
    void IsAlive(bool isAlive);

    void SetSpeed(float speed);

    void CreateFromConfig(EnemyConfig config, Vector2 position);

    public Enemy Get();


}