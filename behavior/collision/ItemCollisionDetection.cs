using Asteroid_game.game_objects.objects;
using GameObjects.objects;
using GameObjects.repositories;

namespace Events.behavior.collision
{
    public class ItemCollisionDetection(IGameObjectRepository gameObjectRepository) : ICollisionDetection
    {

        public void CalculateCollsion()
        {
            foreach (IGameItem item in gameObjectRepository.GameItems)
            {
                var isCollision = ((ICollisionDetection)this).IsCollision((BaseGameEntity)item, gameObjectRepository.Player);
                if (isCollision)
                {
                    item.InteractWithPlayer((Player)gameObjectRepository.Player);
                }

            }
        }
    }
}
