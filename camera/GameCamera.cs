
using Camera;
using GameObjects.Objects;
using Raylib_cs;
using System.Numerics;

namespace Camera;

public class GameCamera : IGameCamera, ICameraController
{
    private Camera2D Camera2D;
    public float Zoom { get; set; } = 1.0f;
    public float Rotation { get; set; } = 0.0f;
    public GameCamera()
    {
        Camera2D = new Camera2D();
    }

    public void CreateCamera(BaseGameEntity gameObject)
    {
        var screenWidth = Raylib.GetScreenWidth();
        var screenHeight = Raylib.GetScreenHeight();
        Camera2D.Target = new Vector2(gameObject.X + ((IMovableEntity)gameObject).MovementSpeed, gameObject.Y + ((IMovableEntity)gameObject).MovementSpeed);
        Camera2D.Offset = new Vector2((screenWidth - 122) / 2, (screenHeight - 182) / 2);
        Camera2D.Rotation = Rotation;
        Camera2D.Zoom = Zoom;
        Raylib.SetMouseOffset(-(int)Camera2D.Offset.X, -(int)Camera2D.Offset.Y);
    }

    public void TargetObject(BaseGameEntity gameObject)
    {
        Camera2D.Target = new Vector2(gameObject.X, gameObject.Y);
    }

    public void SetCamera()
    {
        Raylib.BeginMode2D(Camera2D);
    }

    public Camera2D GetCamera2D()
    {
        return Camera2D;
    }

    public Vector2 ScreenToWorld(Vector2 screenPos)
    {
        return Raylib.GetScreenToWorld2D(screenPos, Camera2D);
    }

    public Vector2 WorldToScreen(Vector2 worldPos)
    {
        return Raylib.GetWorldToScreen2D(worldPos, Camera2D);
    }
}