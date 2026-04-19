using Asteroid_game.camera;

namespace Bevahior
{
    public interface IEventRenderer
    {
        bool CanRender(IGameEvent gameEvent);
        void Render(IGameEvent gameEvent, ICameraController cameraController);
    }
}
