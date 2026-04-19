using System.Numerics;
using Asteroid_game.behavior.movement;
using Asteroid_game.drawing;
using Asteroid_game.game_objects.objects;
using Contentmanagement;

namespace Asteroid_game.game_objects.factories;

public interface IShieldItemFactory
{
    ShieldItem Create(Vector2 position);
}

public class ShieldItemFactory : IShieldItemFactory
{
    public ShieldItem Create(Vector2 position)
    {
        return new ShieldItem(new NoMovement(), new ShieldItemDrawing(),
            (int)position.X, (int)position.Y, 0.5f, 0, Contentmanager.Instance.TexturesForTypes[new Tuple<Type, int>(typeof(ShieldItem), 1)]);
    }
}

