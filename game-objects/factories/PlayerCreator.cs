using System.Numerics;
using Contentmanagement;
using GameObjects.objects;
using Raylib_cs;

namespace GameObjects.factories;

public class PlayerFactory : GameObjectFactory
{
    public override IGameEntity FactoryMethod()
    {
        return new Player(1920 / 2, 1080 / 2, 5f, 3, Contentmanager.Instance.TexturesForTypes[new Tuple<Type, int>(typeof(Player), 1)]);
    }
}