using Behavior.Shooting;
using Drawing;
using GameObjects.Objects;
using GameObjects.Repositories;
using Behavior.Movement;
using Raylib_cs;

public class EnemyBuilder : IGameObjectBuilder
{
    private Enemy _enemy;
    private float _x = 0;
    private float _y = 0;
    private float _movementSpeed = 0;
    private int _hitPoints = 0;
    private Texture2D _texture = new Texture2D();
    private Player _player;


    public EnemyBuilder()
    {



    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    public void Reset()
    {

        this._enemy = new Enemy(new EnemyMovement(), new EnemyDrawing(), new NoShooting(), _player, _x, _y, _texture);
    }

    public void SetTargetPlayer(Player player)
    {
        this._player = player;
    }
    public void CanShoot(int shootingTime)
    {

        _enemy.SetShootingStrategy(new EnemyDefaultShooting(shootingTime));
    }

    public void SetHitpoints(int hitPoints)
    {
        _enemy.IsAlive = true;
        _enemy.HitPointsAtStart = hitPoints;
    }

    public void SetPosition(float x, float y)
    {
        _enemy.X = x;
        _enemy.Y = y;
    }

    public void SetTexture(Texture2D texture2D)
    {
        _enemy.Texture = texture2D;
        _enemy.Widht = texture2D.Width;
        _enemy.Height = texture2D.Height;
    }

    public Enemy GetItem()
    {
        var result = _enemy;
        Reset();
        return result;
    }

    public void IsMovable(bool isMoving)
    {
        _enemy.IsMoving = true;
    }
    public void IsAlive(bool isAlive)
    {
        _enemy.IsAlive = true;
    }
    public void SetSpeed(float speed)
    {
        _enemy.MovementSpeed = speed;
    }
}