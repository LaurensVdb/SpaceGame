using GameObjects.objects;
using GameObjects.repositories;

namespace Asteroid_game.behavior.collision
{
    public class EnemyCollisionDetection(IGameObjectRepository gameObjectRepository) : ICollisionDetection
    {

        public void CalculateCollsion()
        {
            foreach (var entity in gameObjectRepository.Enemies)
            {
                CheckEnemyCollisionWithEnemies(entity);
                CheckEnemyCollisionWithPlayer(entity, (Player)gameObjectRepository.Player);
            }
        }

        private void CheckEnemyCollisionWithEnemies(Enemy enemy1)
        {
            //check if enemy is hitting an other an enemy
            var checkObjects = gameObjectRepository.Enemies.OfType<Enemy>().Except(new[] { enemy1 }).ToList();

            foreach (var checkEnemy in checkObjects)
            {
                var isCollision = ((ICollisionDetection)this).IsCollision(enemy1, checkEnemy);
                if (isCollision)
                {
                    if (enemy1.X <= checkEnemy.X)
                    {
                        enemy1.X -= checkEnemy.MovementSpeed;
                        checkEnemy.X += checkEnemy.MovementSpeed;
                    }
                    if (enemy1.X >= checkEnemy.X)
                    {
                        enemy1.X += enemy1.MovementSpeed;
                        checkEnemy.X -= checkEnemy.MovementSpeed;
                    }
                    if (enemy1.Y <= checkEnemy.Y)
                    {
                        enemy1.Y -= enemy1.MovementSpeed;
                        checkEnemy.Y += checkEnemy.MovementSpeed;
                    }
                    if (enemy1.Y >= checkEnemy.Y)
                    {
                        enemy1.Y += enemy1.MovementSpeed;
                        checkEnemy.Y -= checkEnemy.MovementSpeed;
                    }
                }
            }
        }
        private void CheckEnemyCollisionWithPlayer(Enemy enemy, Player player)
        {
            var isCollision = ((ICollisionDetection)this).IsCollision(enemy, player);
            if (isCollision && enemy.IsAlive)
            {
                player.TakeDamage(1);
                enemy.IsAlive = false;
            }
        }



    }
}
