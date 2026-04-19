using System;
using System.Numerics;
using Asteroid_game.behavior.movement;
using Asteroid_game.drawing;
using Asteroid_game.game_objects.objects;
using Contentmanagement;
using GameObjects.factories;
using GameObjects.objects;

namespace Asteroid_game.game_objects.factories;

public interface IHealtItemFactory
{
    HealthItem Create(Vector2 position);
}

public class HealtItemFactory : IHealtItemFactory
{

    public HealthItem Create(Vector2 position)
    {
        return new HealthItem(new NoMovement(), new HealthItemDrawing(),
                (int)position.X, (int)position.Y, 0.5f, 0, Contentmanager.Instance.TexturesForTypes[new Tuple<Type, int>(typeof(HealthItem), 1)]);

    }
}
