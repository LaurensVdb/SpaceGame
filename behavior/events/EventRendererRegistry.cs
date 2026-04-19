using Asteroid_game.camera;

namespace Bevahior
{
    public class EventRendererRegistry
    {
        private readonly List<IEventRenderer> _renderers = new();

        public void Register(IEventRenderer renderer) => _renderers.Add(renderer);

        public void Render(IGameEvent gameEvent, ICameraController cameraController)
        {
            if (gameEvent == null) return;
            foreach (var r in _renderers)
            {
                if (r.CanRender(gameEvent))
                {
                    r.Render(gameEvent, cameraController);
                    return;
                }
            }
        }
    }
}
