using GameObjects.objects;

namespace MovmementService
{
    public class StarMovement : IMovement
    {
        public void Move(IGameEntity entity)
        {
            CalculateMovement(entity);
        }



        private void CalculateMovement(IGameEntity entity)
        {
            entity.Y += entity.MovementSpeed;
        }
    }
}
