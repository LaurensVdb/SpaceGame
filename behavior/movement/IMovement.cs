using GameObjects.objects;

namespace MovmementService
{
    public interface IMovement
    {
        void Move(IGameEntity entity);
    }
}
