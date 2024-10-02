using bevahior;
using Bevahior;
using Camera;
using Game;
using GameObjects.factories;
using GameObjects.repositories;
using GameStateBevahior;

public class GameWorldCreator : GameWorldFactory
{
    public override IGameState Create()
    {
        var repo=new GameObjectRepository();
        var gameEvents = new List<IGameEvent>
        {
            new ParticleSpawner(repo),
            new EnemySpawner(repo)
        }; 
        return new GameWorld(repo,new GameCamera(),gameEvents);
    }
}