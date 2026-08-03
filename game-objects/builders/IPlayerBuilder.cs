using GameObjects.Objects;

namespace Builders
{

    public interface IPlayerBuilder
    {
        public void Reset();
        void SetHitPoints(int hitPoints);
        public void SetPosition(float x, float y);

        public void SetMovementSpeed(float speed);

        public void SetProtectionLevel(int protectionLevel);
        public Player Get();
    }
}