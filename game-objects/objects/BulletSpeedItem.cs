using Drawing;
using GameObjects.Objects;
using Behavior.Movement;
using Raylib_cs;

namespace GameObjects.Objects
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
