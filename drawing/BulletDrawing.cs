using Camera;
using GameObjects.Objects;
using Raylib_cs;
using System.Numerics;

namespace Drawing
{
    public class BulletDrawing : IDrawing
    {
        public void Drawing(BaseGameEntity gameEntity, ICameraController cameraController)
        {
            if (gameEntity == null) return;

            if (gameEntity.IsAlive)
            {
                Raylib.DrawTexturePro(gameEntity.Texture,
                    new Rectangle(0, 0, gameEntity.Widht, gameEntity.Height),
                    new Rectangle(gameEntity.X, gameEntity.Y, gameEntity.Widht, gameEntity.Height),
                    new Vector2(gameEntity.Widht / 2f, gameEntity.Height / 2f),
                    gameEntity.Rotation,
                    Color.White);
            }
        }
    }
}
