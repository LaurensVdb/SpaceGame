using Camera;
using GameObjects.Objects;
using Raylib_cs;
using System.Numerics;

namespace Drawing
{
    public class PlayerDrawing : IDrawing
    {

        public void Drawing(BaseGameEntity gameEntity, ICameraController cameraController)
        {

            if (gameEntity.ProtectectionLevel > 0)
            {
                Raylib.DrawCircleLines((int)gameEntity.X, (int)gameEntity.Y, 50, Color.Yellow);
            }

            Raylib.DrawTexturePro(gameEntity.Texture, new Rectangle(0, 0, gameEntity.Widht, gameEntity.Height),
                new Rectangle(gameEntity.X, gameEntity.Y, gameEntity.Widht, gameEntity.Height), new Vector2(gameEntity.Widht / 2, gameEntity.Height / 2),
                gameEntity.Rotation, Color.White);

            this.DrawInfo(gameEntity, cameraController);


        }

        private void DrawInfo(BaseGameEntity gameEntity, ICameraController cameraController)
        {
            var postext = cameraController.ScreenToWorld(new Vector2(20, 20));

            Raylib.DrawText($"Life energy: {gameEntity.HitPoints}", (int)postext.X, (int)postext.Y, 20, Color.Gold);

            Raylib.DrawText($"Shield energy: {gameEntity.ProtectectionLevel}", (int)postext.X, (int)postext.Y + 30, 20, Color.Gold);


            Raylib.DrawText($"Enemies killed {gameEntity.KillCount}", (int)postext.X, (int)postext.Y + 60, 20, Color.Gold);

        }



    }
}
