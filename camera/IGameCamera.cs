using GameObjects.objects;
using Raylib_cs;
namespace Camera;

public interface IGameCamera
{
    float Zoom { get; set; }
    float Rotation { get; set; }
    void CreateCamera(IGameEntity gameObject);
    void TargetObject(IGameEntity gameObject);
    void SetCamera();

    Camera2D GetCamera2D();
}