using GameObjects.objects;

namespace Asteroid_game.game_objects.objects
{
    public interface IGameItem
    {
        void InteractWithPlayer(IGameEntity player);
    }
}