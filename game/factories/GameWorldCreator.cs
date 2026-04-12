using Asteroid_game.behavior;
using Asteroid_game.behavior.collision;
using Asteroid_game.behavior.movement;
using Asteroid_game.behavior.shooting;
using Bevahior;
using Camera;
using Game;
using GameObjects.repositories;
using GameStateBevahior;

public class GameWorldCreator : GameWorldFactory
{
    public override IGameState Create()
    {
        var repo = new GameObjectRepository();
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


        return new GameWorld(repo, new GameCamera(), collisionDetectionService, new MovementService(repo),new ShootingService(repo), gameEvents);
    }
}