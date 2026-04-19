using Camera;
using GameObjects.Objects;
using Raylib_cs;
using System.Numerics;

namespace Drawing
{
    public class StarDrawing : IDrawing
    {
        public void Drawing(BaseGameEntity gameEntity, ICameraController cameraController)
        {
            if (gameEntity == null) return;

            Raylib.DrawTextureEx(gameEntity.Texture, new Vector2(gameEntity.X, gameEntity.Y), 0f, 0.2f, Color.White);
        }
    }
}
