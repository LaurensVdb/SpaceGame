using GameObjects.Objects;

namespace Behavior.Movement
{
    public class StarMovement : IMovement
    {
        public void Move(BaseGameEntity entity)
        {
            CalculateMovement(entity);
        }



        private void CalculateMovement(BaseGameEntity entity)
        {
            entity.Y += entity.MovementSpeed;
        }
    }
}
