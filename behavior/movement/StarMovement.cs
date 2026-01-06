using GameObjects.objects;

namespace MovmementService
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
