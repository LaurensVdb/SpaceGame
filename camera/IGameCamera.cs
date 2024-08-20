using GameObjects;
using Raylib_cs;
namespace Camera; 

public interface IGameCamera{
    float Zoom { get; set; }
    float Rotation {get;set;}
    void CreateCamera(BaseGameEntity gameObject,int screenWidth, int screenHeight);
    void TargetObject(BaseGameEntity gameObject);
    void SetCamera();

    Camera2D GetCamera2D();
}