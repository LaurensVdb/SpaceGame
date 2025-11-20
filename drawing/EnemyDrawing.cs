using System;
using System.Collections.Generic;
using System.Text;
using Asteroid_game.camera;
using GameObjects.objects;
using Raylib_cs;
using System.Numerics;

namespace Asteroid_game.drawing
{
    public class EnemyDrawing : IDrawing
    {
        public void Drawing(IGameEntity gameEntity, ICameraController cameraController)
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
