using GameObjects.objects;
using GameObjects.repositories;
namespace Bevahior;

public interface IEnemySpawner {
    void StartEnemySpawner(int screenWidth , int screenHeight,IGameObjectRepository gameObjectRepository, int wave);
}