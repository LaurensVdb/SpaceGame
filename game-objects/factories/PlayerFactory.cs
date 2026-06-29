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
        var player = new Player(new PlayerMovement(), new PlayerDrawing(), new PlayerShooting(500), 1920 / 2, 1080 / 2, 5f, Contentmanager.Instance.TexturesForTypes[new Tuple<Type, int>(typeof(Player), 1)]);
        player.SetHitPoints(10);
        return player;
    }
}