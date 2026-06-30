using Drawing;
using GameObjects.Objects;
using Behavior.Movement;
using Raylib_cs;
using Camera;

namespace GameObjects.Objects
{
    public class BulletSpeedItem : BaseGameEntity, IGameItem, IDrawableEntity
    {
        private readonly IDrawing drawing;

        public BulletSpeedItem(IDrawing drawing, float x, float y, Texture2D texture2D)
            : base(x, y, texture2D)
        {
            this.drawing = drawing;
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

        public void Draw(ICameraController cameraController)
        {
            this.drawing.Drawing(this, cameraController);
        }
    }
}
