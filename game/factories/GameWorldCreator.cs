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
        return new GameWorld(new GameObjectRepository(),new GameCamera(),new EnemySpawner(), new ParticleSpawner());
    }
}