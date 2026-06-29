using Camera;

namespace GameObjects.Objects;

public interface IDrawableEntity
{
    void Draw(ICameraController cameraController);
}