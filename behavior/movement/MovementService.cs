using GameObjects.Objects;
using GameObjects.Repositories;

namespace Behavior.Movement
{
    public class MovementService(IGameObjectRepository gameObjectRepository) : IMovementService
    {
        public void MoveObjects()
        {
            var gameEntities = gameObjectRepository.MovableEntities.ToList();
            foreach (var entity in gameEntities)
            {
                entity.Move();

            }
            var objectToMove = (IMovableEntity)gameObjectRepository.Player;
            objectToMove.Move();
        }
    }
}
