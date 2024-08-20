using GameObjects;

public sealed class GameObjectRepository:IGameObjectRepository{
    public List<BaseGameEntity> Entities { get; set; } = new();
    public BaseGameEntity Player { get; set; } 

    public GameObjectRepository(BaseGameEntity player)
    {
        Player = player;
    }

    public void SetPlayer(BaseGameEntity player){
        Player = player;
    }
    public void AddEntity(BaseGameEntity entity){
        Entities.Add(entity);
    }

    public void RemoveEntity(BaseGameEntity entity){
        Entities.Remove(entity);
    }

  

}