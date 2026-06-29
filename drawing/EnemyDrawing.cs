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
                var damageAbleEntity = (IDamageableEntity)gameEntity;
                int newWidth = 1;
                if (damageAbleEntity.HitPointsAtStart > 0)
                    newWidth = gameEntity.Widht / damageAbleEntity.HitPointsAtStart;

                Raylib.DrawRectangle((int)gameEntity.X, (int)gameEntity.Y - 10, newWidth * damageAbleEntity.HitPoints, 5, Color.Gold);
                Raylib.DrawTextureV(gameEntity.Texture, new Vector2(gameEntity.X, gameEntity.Y), Color.White);
            }
        }
    }
}
