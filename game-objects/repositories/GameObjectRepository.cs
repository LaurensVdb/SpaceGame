using ContentManagement;
using GameObjects.Factories;
using GameObjects.Objects;

namespace GameObjects.Repositories;

public sealed class GameObjectRepository : IGameObjectRepository
{


    public int TotalEnemiesSpawned { get; set; }

    private List<BaseGameEntity> gameEntities;
    public List<BaseGameEntity> Entities => gameEntities;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public BaseGameEntity Player { get; set; }
    public int CurrentWave { get; set; }
    public List<EnemyConfig> EnemyConfgurationData { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    public GameObjectRepository()
    {
        gameEntities = new List<BaseGameEntity>();
    }

    public void CreatePlayer()
    {
        PlayerFactory playerFactory = new PlayerFactory();
        Player = playerFactory.Create();
    }
    public void AddEntity(BaseGameEntity entity)
    {
        Entities.Add(entity);
        if (entity.GetType() == typeof(Enemy))
        {
            TotalEnemiesSpawned++;
        }

    }

    public void RemoveEntity(BaseGameEntity entity)
    {
        Entities.Remove(entity);
    }

    public void RemoveDeadEntities()
    {
        ((ShootableEntity)Player).KillCount += Entities.OfType<Enemy>().Count(e => !e.IsAlive);
        Entities.RemoveAll(e => !e.IsAlive);
    }



}