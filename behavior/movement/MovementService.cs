using GameObjects.Repositories;

namespace Behavior.Movement
{
    public class MovementService(IGameObjectRepository gameObjectRepository) : IMovementService
    {
        public void MoveObjects()
        {
            var gameEntities = gameObjectRepository.Entities.ToList();
            foreach (var entity in gameEntities)
            {
                entity.Move();

            }
            gameObjectRepository.Player.Move();
        }
    }
}
