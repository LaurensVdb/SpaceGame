using Asteroid_game.drawing;
using GameObjects.objects;
using MovmementService;
using Raylib_cs;

namespace Asteroid_game.game_objects.objects
{
    public class BulletSpeedItem : BaseGameEntity, IGameItem
    {
        public BulletSpeedItem(IMovement movementservice, IDrawing drawing, float x, float y, float movementSpeed, int hitPoints, Texture2D texture2D, bool canShoot = false)
            : base(movementservice, drawing, x, y, movementSpeed, hitPoints, texture2D, canShoot)
        {
        }
        private async Task Delayedtask(BaseGameEntity gameEntity)
        {
            await Task.Delay(10000);
            gameEntity.MaxElapsedMillisecondsShootingTime = 100;

        }
        public void InteractWithPlayer(BaseGameEntity player)
        {

            player.MaxElapsedMillisecondsShootingTime = 0;
            IsAlive = false;
            _ = Delayedtask(player);

        }
    }
}
