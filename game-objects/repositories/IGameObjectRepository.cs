using GameObjects.objects;


namespace GameObjects.repositories;
public interface IGameObjectRepository{
    void AddEntity(IGameEntity entity);
    void RemoveEntity(IGameEntity entity);
    List<IGameEntity> Entities { get; }
    IGameEntity Player{get;set;}
    void SetPlayer(IGameEntity player);

    int TotalEnemiesSpawned { get; set; }
    int CurrentWave { get; set; }

}