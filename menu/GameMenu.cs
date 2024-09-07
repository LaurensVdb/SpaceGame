using System.Numerics;
using GameStateBevahior;
using Raylib_cs;

namespace GameMenuBevahior;

public class GameMenu : BaseMenu
{
    public GameMenu(IGameState gameState, List<IMenuItem> menuItems) : base(gameState, menuItems)
    {
        var item = menuItems.First(p=>p.Order==currentMenuOrder);
   
    }

    public override void DrawStartMenu()
    {
        //set title + maybe background stuff 
        Vector2 pos = MenuItems.OrderBy(p=>p.Order).First().Position;
        Raylib.DrawText("MAIN MENU",(int)pos.X,(int)pos.Y-100,50,Color.Gold);
        base.DrawStartMenu();
    }
}