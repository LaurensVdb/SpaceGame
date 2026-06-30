using System;
using System.Numerics;
using Behavior.Movement;
using Drawing;
using GameObjects.Objects;
using ContentManagement;
using GameObjects.Factories;

namespace GameObjects.Factories;

public interface IHealtItemFactory
{
    HealthItem Create(Vector2 position);
}

public class HealtItemFactory : IHealtItemFactory
{

    public HealthItem Create(Vector2 position)
    {
        return new HealthItem(new HealthItemDrawing(),
                (int)position.X, (int)position.Y, Contentmanager.Instance.TexturesForTypes[new Tuple<Type, int>(typeof(HealthItem), 1)]);

    }
}
