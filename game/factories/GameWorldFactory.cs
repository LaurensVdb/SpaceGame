using Behavior.Movement;
using Behavior.Shooting;
using Behavior.Events;
using Camera;
using ContentManagement;
using Behavior.Collision;
using Game;
using GameObjects.Repositories;
using GameState;

public interface IGameWorldFactory
{
    IGameState Create();
}

public class GameWorldFactory : IGameWorldFactory
{
    public IGameState Create()
    {
        var repo = new GameObjectRepository();
        var config = new EnemyConfigLoader().Load("configuration/enemies.json");
        repo.EnemyConfgurationData = config;

        var gameEvents = new List<IGameEvent>
        {
            new ParticleSpawner(repo,200),
            new PlayerHealtItemSpawner(repo,10000),
            new WaveEvent(repo,10000),
            new ShieldItemSpawner(repo,20000),
            new BulletSpeedItemSpawner(repo,21000)
        };

        var collisionDetectionService = new CollisionDetectionService(new ICollisionDetection[]
        {
            new EnemyCollisionDetection(repo),
            new BulletCollisionDetection(repo),
            new ItemCollisionDetection(repo)
        });


        return new GameWorld(repo, new GameCamera(), collisionDetectionService, new MovementService(repo), new ShootingService(repo), gameEvents);
    }
}