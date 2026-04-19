using System.Numerics;
using GameState;
using Raylib_cs;

namespace Menu;

public class GameOverMenu : BaseMenu
{
    public GameOverMenu(List<IMenuItem> menuItems) : base(menuItems)
    {
    }


    public override void Draw()
    {
        //Title screen + maybe bacbkground
        Vector2 pos = MenuItems.OrderBy(p => p.Order).First().Position;
        Raylib.DrawText("GAME OVER! YOU DIED!", (int)pos.X, (int)pos.Y - 100, 50, Color.Gold);
        //loop over existing menu items
        base.Draw();
    }
}