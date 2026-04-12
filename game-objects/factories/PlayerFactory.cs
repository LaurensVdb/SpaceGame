using System.Numerics;
using Asteroid_game.behavior.shooting;
using Asteroid_game.drawing;
using Contentmanagement;
using GameObjects.objects;
using MovmementService;

namespace GameObjects.factories;

public class PlayerFactory : GameObjectFactory
{
    public override BaseGameEntity Create()
    {
        return new Player(new PlayerMovement(), new PlayerDrawing(),new PlayerShooting(500), 1920 / 2, 1080 / 2, 5f, 3, Contentmanager.Instance.TexturesForTypes[new Tuple<Type, int>(typeof(Player), 1)]);
    }

    public override BaseGameEntity Create(Vector2 position)
    {
        return new Player(new PlayerMovement(), new PlayerDrawing(),new PlayerShooting(500), position.X, position.Y, 5f, 3, Contentmanager.Instance.TexturesForTypes[new Tuple<Type, int>(typeof(Player), 1)]);
    }
}