using System;
using System.Diagnostics;
using System.Numerics;
using GameObjects.Objects;

namespace Behavior.Shooting;

public interface IShooting
{
    Bullet? Shooting(Vector2 position, float rotatepoint);
    Stopwatch shootTimer { get; set; }
    int MaxElapsedMilliseconds { get; set; }
}
