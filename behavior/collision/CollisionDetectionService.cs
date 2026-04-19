namespace Behavior.Collision
{

    public class CollisionDetectionService(IEnumerable<ICollisionDetection> collisionDetections) : ICollisionDetectionService
    {

        public void CollisionDetection()
        {
            foreach (var collisionDetection in collisionDetections)
            {
                collisionDetection.CalculateCollsion();
            }
        }


    }
}
