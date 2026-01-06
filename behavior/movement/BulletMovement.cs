using GameObjects.objects;

namespace MovmementService
{
    public class BulletMovement : IMovement
    {
        public void Move(BaseGameEntity entity)
        {
            CalculateMovement(entity);
        }
        private void CalculateMovement(BaseGameEntity entity)
        {
            entity.X += MathF.Cos((entity.Rotation - 90) * (MathF.PI / 180)) * entity.MovementSpeed;
            entity.Y += MathF.Sin((entity.Rotation - 90) * (MathF.PI / 180)) * entity.MovementSpeed;
        }
    }
}
