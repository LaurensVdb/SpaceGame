using Asteroid_game.drawing;
using GameObjects.objects;
using MovmementService;
using Raylib_cs;

namespace Asteroid_game.game_objects.objects
{
    public class HealthItem : BaseGameEntity, IGameItem
    {
        public HealthItem(IMovement movementservice, IDrawing drawing, float x, float y, float movementSpeed, int hitPoints, Texture2D texture2D, bool canShoot = false)
            : base(movementservice, drawing, x, y, movementSpeed, hitPoints, texture2D, canShoot)
        {
        }

        public void InteractWithPlayer(IGameEntity player)
        {
            player.HitPoints++;
            this.IsAlive = false;

        }
    }
}
