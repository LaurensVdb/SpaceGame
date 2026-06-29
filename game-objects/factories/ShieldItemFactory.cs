using System.Numerics;
using Behavior.Movement;
using Drawing;
using GameObjects.Objects;
using ContentManagement;

namespace GameObjects.Factories;

public interface IShieldItemFactory
{
    ShieldItem Create(Vector2 position);
}

public class ShieldItemFactory : IShieldItemFactory
{
    public ShieldItem Create(Vector2 position)
    {
        return new ShieldItem(new ShieldItemDrawing(),
            (int)position.X, (int)position.Y, 0.5f, 0, Contentmanager.Instance.TexturesForTypes[new Tuple<Type, int>(typeof(ShieldItem), 1)]);
    }
}

