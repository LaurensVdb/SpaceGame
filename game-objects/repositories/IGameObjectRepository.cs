using GameObjects;

public interface IGameObjectRepository{
    void AddEntity(BaseGameEntity entity);
    void RemoveEntity(BaseGameEntity entity);
    List<BaseGameEntity> Entities { get; set; }
    BaseGameEntity Player{get;set;}
    void SetPlayer(BaseGameEntity player);
    
}