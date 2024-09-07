using System.Numerics;
using GameStateBevahior;
using Raylib_cs;

namespace GameMenuBevahior;

public class GameOverMenu : BaseMenu
{
    public GameOverMenu(IGameState gameState, List<IMenuItem> menuItems) : base(gameState, menuItems)
    {
    }

    public override void DrawStartMenu()
    {
        //Title screen + maybe bacbkground
        Vector2 pos = MenuItems.OrderBy(p=>p.Order).First().Position;
        Raylib.DrawText("GAME OVER! YOU DIED!",(int)pos.X,(int)pos.Y-100,50,Color.Gold);
        //loop over existing menu items
        base.DrawStartMenu();
    }
}