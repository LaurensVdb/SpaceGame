using System;
using System.Diagnostics;
using System.Numerics;
using Asteroid_game.game_objects.objects;
using GameObjects.objects;
using GameObjects.repositories;

namespace Asteroid_game.behavior.shooting;

public interface IShooting
{
    Bullet? Shooting(Vector2 position,float rotatepoint);
    Stopwatch shootTimer{get;set;}
    int MaxElapsedMilliseconds{get;set;}
}
