using System;
using System.Numerics;
using GameObjects.Objects;
using GameObjects.Repositories;

namespace Behavior.Shooting;

public interface IShootingService
{
    void Shoot();
}

public class ShootingService : IShootingService
{
    private readonly GameObjectRepository gameObjectRepository;

    public ShootingService(GameObjectRepository gameObjectRepository)
    {
        this.gameObjectRepository = gameObjectRepository;
    }

    public void Shoot()
    {
        PlayerShooting();
        EnemiesShooting();

    }

    private void EnemiesShooting()
    {
        var gameEntities = gameObjectRepository.Entities.OfType<Enemy>().ToList();
        foreach (var entity in gameEntities)
        {
            var bullet = entity.Shoot();
            if (bullet != null)
            {
                gameObjectRepository.AddEntity(bullet);
            }

        }
    }
    private void PlayerShooting()
    {
        var gameEntities = (Player)gameObjectRepository.Player;
        var bullet = gameEntities.Shoot();
        if (bullet != null)
        {
            gameObjectRepository.AddEntity(bullet);
        }
    }
}
