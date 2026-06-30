using Drawing;
using GameObjects.Objects;
using Behavior.Movement;
using Raylib_cs;
using Camera;

namespace GameObjects.Objects
{
    public class ShieldItem : BaseGameEntity, IGameItem, IDrawableEntity
    {
        private readonly IDrawing drawing;

        public ShieldItem(IDrawing drawing, float x, float y, Texture2D texture2D)
            : base(x, y, texture2D)
        {
            this.drawing = drawing;
        }

        public void Draw(ICameraController cameraController)
        {
            this.drawing.Drawing(this, cameraController);
        }

        public void InteractWithPlayer(Player player)
        {
            player.ProtectectionLevel = 10;
            IsAlive = false;
        }
    }
}
