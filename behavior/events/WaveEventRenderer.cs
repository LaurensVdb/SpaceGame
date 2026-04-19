using Asteroid_game.camera;
using Asteroid_game.drawing;


namespace Bevahior
{
    public class WaveEventRenderer : IEventRenderer
    {
        private readonly WaveEventDrawing _drawing = new();

        public bool CanRender(IGameEvent gameEvent) => gameEvent is WaveEvent;

        public void Render(IGameEvent gameEvent, ICameraController cameraController)
        {
            _drawing.Draw((WaveEvent)gameEvent, cameraController);
        }
    }
}
