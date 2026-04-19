using System.Numerics;

namespace Camera
{
    public interface ICameraController
    {
        Vector2 ScreenToWorld(Vector2 screenPos);
        Vector2 WorldToScreen(Vector2 worldPos);


    }
}
