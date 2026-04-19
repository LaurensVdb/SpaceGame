using GameObjects.objects;
using Raylib_cs;

namespace Events.behavior.collision
{
    public interface ICollisionDetection
    {
        void CalculateCollsion();

        bool IsCollision(BaseGameEntity entityCollisionCheckA, BaseGameEntity entityCollisionCheckB)
        {

            return Raylib.CheckCollisionRecs(entityCollisionCheckA.CollisionRectangle, entityCollisionCheckB.CollisionRectangle);
        }
    }
}
