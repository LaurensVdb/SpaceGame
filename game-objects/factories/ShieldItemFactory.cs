using System;
using System.Numerics;
using Asteroid_game.behavior.movement;
using Asteroid_game.drawing;
using Asteroid_game.game_objects.objects;
using Contentmanagement;
using GameObjects.factories;
using GameObjects.objects;

namespace Asteroid_game.game_objects.factories;

public class ShieldItemFactory:GameObjectFactory
{
    public override BaseGameEntity Create()
    {
        throw new NotImplementedException();
    }

    public override BaseGameEntity Create(Vector2 position)
    {
        return new ShieldItem(new NoMovement(), new ShieldItemDrawing(),
            (int)position.X, (int)position.Y, 0.5f, 0, Contentmanager.Instance.TexturesForTypes[new Tuple<Type, int>(typeof(ShieldItem), 1)]);
    }
}

