using GameObjects.objects;
using GameObjects.repositories;
using System.Numerics;

namespace MovmementService
{
    public class EnemyMovement(IGameObjectRepository repository) : IMovement
    {
        public void Move(IGameEntity entity)
        {
            var targetPosition = new Vector2(repository.Player.CollisionRectangle.X, repository.Player.CollisionRectangle.Y);
            CalculateMovement(entity, targetPosition);
        }

        private void CalculateMovement(IGameEntity entity, Vector2 targetPosition)
        {
            if (entity.IsMoving)
            {
                if (entity.X <= targetPosition.X)
                {
                    entity.X += entity.MovementSpeed;
                }
                if (entity.X >= targetPosition.X)
                {
                    entity.X -= entity.MovementSpeed;
                }
                if (entity.Y <= targetPosition.Y)
                {
                    entity.Y += entity.MovementSpeed;
                }
                if (entity.Y >= targetPosition.Y)
                {
                    entity.Y -= entity.MovementSpeed;
                }
            }
        }
    }
}
