using GameObjects.objects;


namespace GameObjects.repositories;
public interface IGameObjectRepository{
    void AddEntity(IGameEntity entity);
    void RemoveEntity(IGameEntity entity);
    List<IGameEntity> Entities { get; set; }
    IGameEntity Player{get;set;}
    void SetPlayer(IGameEntity player);
    
}