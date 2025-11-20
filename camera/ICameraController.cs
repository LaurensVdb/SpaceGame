using System.Numerics;

namespace Asteroid_game.camera
{
    public interface ICameraController
    {
        Vector2 ScreenToWorld(Vector2 screenPos);
        Vector2 WorldToScreen(Vector2 worldPos);


    }
}
