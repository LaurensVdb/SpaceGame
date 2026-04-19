using Camera;
using GameObjects.Objects;
using Raylib_cs;
using System.Numerics;

namespace Drawing
{
    public class EnemyDrawing : IDrawing
    {
        public void Drawing(BaseGameEntity gameEntity, ICameraController cameraController)
        {
            if (gameEntity == null) return;

            if (gameEntity.IsAlive)
            {
                int newWidth = 1;
                if (gameEntity.HitPointsAtStart > 0)
                    newWidth = gameEntity.Widht / gameEntity.HitPointsAtStart;

                Raylib.DrawRectangle((int)gameEntity.X, (int)gameEntity.Y - 10, newWidth * gameEntity.HitPoints, 5, Color.Gold);
                Raylib.DrawTextureV(gameEntity.Texture, new Vector2(gameEntity.X, gameEntity.Y), Color.White);
            }
        }
    }
}
