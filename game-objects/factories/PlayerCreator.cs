using Contentmanagement;
using GameObjects.objects;
using MovmementService;

namespace GameObjects.factories;

public class PlayerFactory : GameObjectFactory
{
    public override IGameEntity FactoryMethod()
    {
        return new Player(new PlayerMovement(), 1920 / 2, 1080 / 2, 5f, 3, Contentmanager.Instance.TexturesForTypes[new Tuple<Type, int>(typeof(Player), 1)]);
    }
}