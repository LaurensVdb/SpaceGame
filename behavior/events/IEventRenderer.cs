using Camera;

namespace Behavior.Events
{
    public interface IEventRenderer
    {
        bool CanRender(IGameEvent gameEvent);
        void Render(IGameEvent gameEvent, ICameraController cameraController);
    }
}
