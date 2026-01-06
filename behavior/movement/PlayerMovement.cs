using GameObjects.objects;
using Raylib_cs;

namespace MovmementService
{
    public class PlayerMovement() : IMovement
    {
        public void Move(BaseGameEntity entity)
        {
            CalculateMovement(entity);
        }

        private void CalculateMovement(BaseGameEntity entity)
        {

            var mousePosition = Raylib.GetMousePosition();
            float deltaX = mousePosition.X;
            float deltaY = mousePosition.Y;
            entity.Rotation = MathF.Atan2(deltaY, deltaX) * (180f / MathF.PI) + 90;

            if (Raylib.IsKeyDown(KeyboardKey.Right))
            {
                if (Raylib.IsKeyDown(KeyboardKey.Right)) entity.X += entity.MovementSpeed;
            }
            if (Raylib.IsKeyDown(KeyboardKey.Left)) entity.X -= entity.MovementSpeed;
            if (Raylib.IsKeyDown(KeyboardKey.Up)) entity.Y -= entity.MovementSpeed;
            if (Raylib.IsKeyDown(KeyboardKey.Down)) entity.Y += entity.MovementSpeed;



        }
    }
}
