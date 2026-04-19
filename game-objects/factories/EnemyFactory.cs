using System;
using System.Numerics;
using Contentmanagement;
using GameObjects.factories;
using GameObjects.objects;

namespace Asteroid_game.game_objects.factories;

public interface IEnemyFactory
{
    Enemy Create(EnemyConfig config, Vector2 position);
}

public class EnemyFactory : IEnemyFactory
{

    public Enemy Create(EnemyConfig config, Vector2 position)
    {
        var enemyBuilder = new EnemyBuilder();
        enemyBuilder.SetTargetPlayer(config.TargetPlayer);
        enemyBuilder.Reset();
        enemyBuilder.SetPosition(position.X, position.Y);
        enemyBuilder.IsAlive(true);
        enemyBuilder.IsMovable(true);
        enemyBuilder.SetTexture(
            Contentmanager.Instance.TexturesForTypes[
                new Tuple<Type, int>(typeof(Enemy), config.TextureId)]);
        enemyBuilder.SetSpeed(config.Speed);
        enemyBuilder.SetHitpoints(config.HitPoints);

        if (config.CanShoot && config.ShootInterval.HasValue)
        {
            enemyBuilder.CanShoot(config.ShootInterval.Value);
        }

        return enemyBuilder.GetItem();
    }
}
