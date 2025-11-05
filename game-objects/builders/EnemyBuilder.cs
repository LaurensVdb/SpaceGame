using GameObjects.objects;
using GameObjects.repositories;
using MovmementService;
using Raylib_cs;

public class EnemyBuilder : IGameObjectBuilder
{
    Enemy enemy;
    private float x;
    private float y;
    private float movementSpeed;
    private int hitPoints;
    private bool canshoot;
    private Texture2D texture;
    private readonly IGameObjectRepository _repository;

    public EnemyBuilder(IGameObjectRepository repository)
    {
        _repository = repository;
        Reset();
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    public void Reset()
    {
        this.enemy = new Enemy(new EnemyMovement(_repository), x, y, movementSpeed, hitPoints, texture, canshoot);
    }
    public void CanShoot(int shootingTime)
    {
        enemy.CanShoot = true;
        enemy.MaxElapsedMillisecondsShootingTime = shootingTime;
    }

    public void SetHitpoints(int hitPoints)
    {
        enemy.IsAlive = true;
        enemy.SetHitPoints(hitPoints);
    }

    public void SetPosition(float x, float y)
    {
        enemy.X = x;
        enemy.Y = y;
    }

    public void SetTexture(Texture2D texture2D)
    {
        enemy.Texture = texture2D;
        enemy.Widht = texture2D.Width;
        enemy.Height = texture2D.Height;
    }

    public Enemy GetItem()
    {
        var result = enemy;
        Reset();
        return result;
    }

    public void IsMovable(bool isMoving)
    {
        enemy.IsMoving = true;
    }
    public void IsAlive(bool isAlive)
    {
        enemy.IsAlive = true;
    }
    public void SetSpeed(float speed)
    {
        enemy.MovementSpeed = speed;
    }
}