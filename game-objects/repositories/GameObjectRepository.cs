using GameObjects.objects;

namespace GameObjects.repositories;
public sealed class GameObjectRepository:IGameObjectRepository{
 

    public List<IGameEntity> Entities { get; set; } = new();
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public IGameEntity Player { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.



    public void SetPlayer(IGameEntity player){
        Player = player;
    }
    public void AddEntity(IGameEntity entity){
        Entities.Add(entity);
    }

    public void RemoveEntity(IGameEntity entity){
        Entities.Remove(entity);
    }

  

}