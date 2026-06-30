using System;
using System.Numerics;
using Behavior.Movement;
using Drawing;
using GameObjects.Objects;
using ContentManagement;
using GameObjects.Factories;

namespace GameObjects.Factories;

public interface IBulletSpeedItemFactory
{
    BulletSpeedItem Create(Vector2 position);
}

public class BulletSpeedItemFactory : IBulletSpeedItemFactory
{
    public BulletSpeedItem Create(Vector2 position)
    {
        return new BulletSpeedItem(new BulletSpeedItemDrawing(),
                  (int)position.X, (int)position.Y, Contentmanager.Instance.TexturesForTypes[new Tuple<Type, int>(typeof(BulletSpeedItem), 1)]);
    }
}
