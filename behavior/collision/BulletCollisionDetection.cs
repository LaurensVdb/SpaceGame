using GameObjects.objects;
using GameObjects.repositories;

namespace Asteroid_game.behavior.collision
{
    public class BulletCollisionDetection(IGameObjectRepository gameObjectRepository) : ICollisionDetection
    {
        public void CalculateCollsion()
        {
            EnemyBulletsCollsionDetection();
            PlayerBulletsCollisionDetection();
        }
        private void EnemyBulletsCollsionDetection()
        {

            foreach (Bullet bullet in gameObjectRepository.BulletsEnemie)
            {
                CheckCollision(bullet, gameObjectRepository.Player);

            }
        }
        private void PlayerBulletsCollisionDetection()
        {
            foreach (Bullet bullet in gameObjectRepository.BulletsPlayer)
            {
                foreach (Enemy enemy in gameObjectRepository.Enemies)
                {
                    CheckCollision(bullet, enemy);
                    //IncreaseKillcountWhenEnemyIsDead(enemy);
                }
            }
        }

        private bool CheckCollision(Bullet bullet, BaseGameEntity entityCollision)
        {
            var isCollision = ((ICollisionDetection)this).IsCollision(bullet, entityCollision);
            if (isCollision && bullet.IsAlive)
            {
                bullet.IsAlive = false;
                entityCollision.TakeDamage(1);
            }
            return isCollision;
        }

    }
}
