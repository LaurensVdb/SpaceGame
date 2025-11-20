using Asteroid_game.camera;
using GameObjects.objects;
using Raylib_cs;
using System.Numerics;

namespace Asteroid_game.drawing
{
    public class HealthItemDrawing : IDrawing
    {
        public void Drawing(IGameEntity gameEntity, ICameraController cameraController)
        {
            if (gameEntity == null) return;

            if (gameEntity.IsAlive)
            {
                Raylib.DrawTextureV(gameEntity.Texture, new Vector2(gameEntity.X, gameEntity.Y), Color.Yellow);
            }
        }
    }
}
