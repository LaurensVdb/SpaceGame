using System.Numerics;
using Behavior.Shooting;
using Drawing;
using ContentManagement;
using GameObjects.Objects;
using Behavior.Movement;

namespace GameObjects.Factories;

public interface IPlayerFactory
{
    Player Create();
}

public class PlayerFactory : IPlayerFactory
{
    public Player Create()
    {
        return new Player(new PlayerMovement(), new PlayerDrawing(), new PlayerShooting(500), 1920 / 2, 1080 / 2, 5f, 3, Contentmanager.Instance.TexturesForTypes[new Tuple<Type, int>(typeof(Player), 1)]);
    }
}