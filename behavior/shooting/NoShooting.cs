using System;
using System.Diagnostics;
using System.Numerics;
using GameObjects.Objects;

namespace Behavior.Shooting;

public class NoShooting : IShooting
{
    public Stopwatch shootTimer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int MaxElapsedMilliseconds { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public Bullet? Shooting(Vector2 position, float rotatepoint)
    {
        return null;
    }


}
