namespace Bevahior;
using GameObjects.objects;
using GameObjects.repositories;
public interface IParticleSpawner{
     void StartParticleSpawner(int screenWidth , int screenHeight,IGameObjectRepository gameObjectRepository);
}