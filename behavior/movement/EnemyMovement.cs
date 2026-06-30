using GameObjects.Objects;
using GameObjects.Repositories;
using System.Numerics;

namespace Behavior.Movement
{
    public class EnemyMovement() : IMovement
    {
        public void Move(BaseGameEntity entity)
        {
            var enemy = (Enemy)entity;
            var targetPosition = new Vector2(enemy.TargetPlayer.CollisionRectangle.X, enemy.TargetPlayer.CollisionRectangle.Y);
            CalculateMovement(entity, targetPosition);
        }

        private void CalculateMovement(BaseGameEntity entity, Vector2 targetPosition)
        {
            if (((IMovableEntity)entity).IsMoving)
            {
                if (entity.X <= targetPosition.X)
                {
                    entity.X += ((IMovableEntity)entity).MovementSpeed;
                }
                if (entity.X >= targetPosition.X)
                {
                    entity.X -= ((IMovableEntity)entity).MovementSpeed;
                }
                if (entity.Y <= targetPosition.Y)
                {
                    entity.Y += ((IMovableEntity)entity).MovementSpeed;
                }
                if (entity.Y >= targetPosition.Y)
                {
                    entity.Y -= ((IMovableEntity)entity).MovementSpeed;
                }
            }
        }
    }
}
