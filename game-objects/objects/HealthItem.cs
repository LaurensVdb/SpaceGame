using Drawing;
using GameObjects.Objects;
using Behavior.Movement;
using Raylib_cs;
using Camera;

namespace GameObjects.Objects
{
    public class HealthItem : BaseGameEntity, IGameItem, IDrawableEntity
    {
        private readonly IDrawing drawing;

        public HealthItem(IDrawing drawing, float x, float y, float movementSpeed, Texture2D texture2D)
            : base(x, y, movementSpeed, texture2D)
        {
            this.drawing = drawing;
        }

        public void Draw(ICameraController cameraController)
        {
            this.drawing.Drawing(this, cameraController);
        }

        public void InteractWithPlayer(Player player)
        {
            player.HitPoints++;
            this.IsAlive = false;
        }
    }
}
