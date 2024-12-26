using Asteroid_game.behavior;
using Bevahior;
using Camera;
using Game;
using GameObjects.repositories;
using GameStateBevahior;

public class GameWorldCreator : GameWorldFactory
{
    public override IGameState Create()
    {
        var repo=new GameObjectRepository();
        var gameEvents = new List<IGameEvent>
        {
            new ParticleSpawner(repo,200),
            new PlayerItemSpawner(repo,10000),
            new WaveEvent(repo,10000), 
            new ShieldItemSpawner(repo,20000)
        }; 
        return new GameWorld(repo,new GameCamera(),gameEvents);
    }
}