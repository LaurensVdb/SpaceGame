using Asteroid_game.behavior.shooting;
using Asteroid_game.drawing;
using Contentmanagement;
using GameObjects.objects;
using MovmementService;

namespace GameObjects.factories;

public class PlayerFactory : GameObjectFactory
{
    public override BaseGameEntity FactoryMethod()
    {
        return new Player(new PlayerMovement(), new PlayerDrawing(),new PlayerShooting(100), 1920 / 2, 1080 / 2, 5f, 3, Contentmanager.Instance.TexturesForTypes[new Tuple<Type, int>(typeof(Player), 1)]);
    }
}