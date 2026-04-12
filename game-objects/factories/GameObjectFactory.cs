using System.Numerics;
using GameObjects.objects;
using Raylib_cs;

namespace GameObjects.factories;

public abstract class GameObjectFactory
{
    public abstract BaseGameEntity Create();

    public abstract BaseGameEntity Create(Vector2 position);
}