using Bevahior;
using Camera;
using Game;
using GameObjects.factories;
using GameObjects.repositories;
using GameStateBevahior;

public class GameWorldCreator : GameWorldFactory
{
    public override IGameWorld Create()
    {
        return new GameWorld(new GameObjectRepository(),GameState.Instance,new GameCamera(),new EnemySpawner(), new ParticleSpawner(), 1920, 1080);
    }
}