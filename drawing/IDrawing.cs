using Asteroid_game.camera;
using GameObjects.objects;

namespace Asteroid_game.drawing
{
    public interface IDrawing
    {
        void Drawing(BaseGameEntity gameEntity, ICameraController cameraController);
    }
}
