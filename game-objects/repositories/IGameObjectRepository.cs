using GameObjects.Objects;
using ContentManagement;

namespace GameObjects.Repositories;

public interface IGameObjectRepository
{
    void AddEntity(BaseGameEntity entity);
    void RemoveEntity(BaseGameEntity entity);
    List<BaseGameEntity> Entities { get; }
    BaseGameEntity Player { get; set; }
    void CreatePlayer();
    void RemoveDeadEntities();

    int TotalEnemiesSpawned { get; set; }
    int CurrentWave { get; set; }
    IEnumerable<Bullet> BulletsEnemie => Entities.OfType<Bullet>().Where(p => p.IsAlive && p.IsEnemy);

    IEnumerable<Bullet> BulletsPlayer => Entities.OfType<Bullet>().Where(p => p.IsAlive && !p.IsEnemy);
    IEnumerable<Enemy> Enemies => Entities.OfType<Enemy>().Where(p => p.IsAlive);

    IEnumerable<IGameItem> GameItems => Entities.OfType<IGameItem>();

    IEnumerable<IMovableEntity> MovableEntities => Entities.OfType<IMovableEntity>();

    List<EnemyConfig> EnemyConfgurationData { get; set; }
    PlayerConfig PlayerConfigurationData { get; set; }
}