using Behavior.Shooting;
using Drawing;
using GameObjects.Objects;
using Behavior.Movement;
using Raylib_cs;
using ContentManagement;
using System.Numerics;

public class EnemyBuilder : IEnemyBuilder
{
    private Enemy _enemy;
    public EnemyBuilder()
    {
        Reset();
    }


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    public void Reset()
    {

        this._enemy = new Enemy(new EnemyMovement(), new EnemyDrawing(), new NoShooting(), 0, 0, default);
    }

    public void SetTargetPlayer(Player player)
    {
        this._enemy.TargetPlayer = player;
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

    public Enemy Get()
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
    public void CreateFromConfig(EnemyConfig config, Vector2 position)
    {
        this.SetTargetPlayer(config.TargetPlayer);
        this.SetPosition(position.X, position.Y);
        this.IsAlive(true);
        this.IsMovable(true);
        this.SetTexture(
            Contentmanager.Instance.TexturesForTypes[
                new Tuple<Type, int>(typeof(Enemy), config.TextureId)]);
        this.SetSpeed(config.Speed);
        this.SetHitpoints(config.HitPoints);

        if (config.CanShoot && config.ShootInterval.HasValue)
        {
            this.CanShoot(config.ShootInterval.Value);
        }

    }

}