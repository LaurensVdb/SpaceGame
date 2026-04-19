using GameObjects.Objects;
using Raylib_cs;

namespace Behavior.Collision
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
