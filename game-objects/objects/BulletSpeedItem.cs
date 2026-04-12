using Asteroid_game.drawing;
using GameObjects.objects;
using MovmementService;
using Raylib_cs;

namespace Asteroid_game.game_objects.objects
{
    public class BulletSpeedItem : BaseGameEntity, IGameItem
    {
        public BulletSpeedItem(IMovement movementservice, IDrawing drawing, float x, float y, float movementSpeed, int hitPoints, Texture2D texture2D)
            : base(movementservice, drawing, x, y, movementSpeed, hitPoints, texture2D)
        {
        }
        private async Task Delayedtask(Player gameEntity)
        {
            await Task.Delay(10000);
            gameEntity.ShootingService.MaxElapsedMilliseconds = 500;

        }
        public void InteractWithPlayer(Player gameEntity)
        {

            gameEntity.ShootingService.MaxElapsedMilliseconds = 0;
            IsAlive = false;
            _ = Delayedtask(gameEntity);

        }
    }
}
