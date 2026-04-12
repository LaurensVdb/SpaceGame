using GameObjects.objects;
using GameObjects.repositories;
using System.Numerics;

namespace MovmementService
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
