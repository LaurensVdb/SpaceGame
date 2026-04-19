using Camera;
using GameObjects.Objects;
using Raylib_cs;
using System.Numerics;

namespace Drawing
{
    public class HealthItemDrawing : IDrawing
    {
        public void Drawing(BaseGameEntity gameEntity, ICameraController cameraController)
        {
            if (gameEntity == null) return;

            if (gameEntity.IsAlive)
            {
                Raylib.DrawTextureV(gameEntity.Texture, new Vector2(gameEntity.X, gameEntity.Y), Color.Yellow);
            }
        }
    }
}
