using Asteroid_game.camera;
using Bevahior;
using Raylib_cs;
using System.Numerics;

namespace Asteroid_game.drawing
{
    public class WaveEventDrawing
    {
        public void Draw(WaveEvent waveEvent, ICameraController cameraController)
        {
            var pos = cameraController.ScreenToWorld(new Vector2(20, 100));
            if (waveEvent == null) return;

            if (waveEvent.CurrentWaveIsActive)
            {
                Raylib.DrawText($"Current wave: {waveEvent.Repository.CurrentWave}", (int)pos.X, (int)pos.Y, 20, Color.Gold);
            }
            else
            {
                var elapsedTime = (waveEvent.MaxPauseMilliseconds - waveEvent.TimerElapsedMilliseconds) / 1000;
                Raylib.DrawText($"pause: {elapsedTime}", (int)pos.X, (int)pos.Y, 20, Color.Gold);
            }
        }
    }
}
