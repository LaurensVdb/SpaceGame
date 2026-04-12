using System;
using System.Diagnostics;
using System.Numerics;
using GameObjects.objects;
using GameObjects.repositories;

namespace Asteroid_game.behavior.shooting;

public class NoShooting : IShooting
{
    public Stopwatch shootTimer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int MaxElapsedMilliseconds { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public Bullet? Shooting(Vector2 position, float rotatepoint)
    {
       return null;
    }

   
}
