using System;
using System.Numerics;
using Asteroid_game.behavior.movement;
using Asteroid_game.drawing;
using Asteroid_game.game_objects.objects;
using Contentmanagement;
using GameObjects.factories;
using GameObjects.objects;

namespace Asteroid_game.game_objects.factories;

public interface IBulletSpeedItemFactory
{
    BulletSpeedItem Create(Vector2 position);
}

public class BulletSpeedItemFactory : IBulletSpeedItemFactory
{
    public BulletSpeedItem Create(Vector2 position)
    {
        return new BulletSpeedItem(new NoMovement(), new BulletSpeedItemDrawing(),
                  (int)position.X, (int)position.Y, 0.5f, 0, Contentmanager.Instance.TexturesForTypes[new Tuple<Type, int>(typeof(BulletSpeedItem), 1)]);
    }
}
