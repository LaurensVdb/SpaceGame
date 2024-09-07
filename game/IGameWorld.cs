using Bevahior;
using Camera;
using GameObjects.factories;
using GameObjects.repositories;

namespace Game;

public interface IGameWorld{
    IGameObjectRepository GameObjectRepository { get; set; }
    IGameCamera GameCamera { get; set; }
    IEnemySpawner EnemySpawner { get; set; }

    IParticleSpawner ParticleSpawner { get; set; }

    int ScreenWidth{get;}
    int ScreenHeight{get;}
    int Wave  {get;set;}
}