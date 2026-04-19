using GameObjects.Objects;
using GameObjects.Repositories;

namespace Behavior.Collision
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
