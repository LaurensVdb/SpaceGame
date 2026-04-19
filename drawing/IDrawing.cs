using Camera;
using GameObjects.Objects;

namespace Drawing
{
    public interface IDrawing
    {
        void Drawing(BaseGameEntity gameEntity, ICameraController cameraController);
    }
}
