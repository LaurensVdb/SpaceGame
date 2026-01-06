using Asteroid_game.camera;
using GameObjects.objects;
using Raylib_cs;
using System.Numerics;

namespace Asteroid_game.drawing
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
