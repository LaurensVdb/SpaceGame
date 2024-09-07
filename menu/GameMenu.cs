using System.Numerics;
using GameStateBevahior;
using Raylib_cs;

namespace GameMenuBevahior;

public class GameMenu : BaseMenu
{
    public GameMenu(List<IMenuItem> menuItems) : base(menuItems)
    {
        var item = menuItems.First(p=>p.Order==currentMenuOrder);
   
    }
    
    public override void Draw()
    {
        //set title + maybe background stuff 
        Vector2 pos = MenuItems.OrderBy(p=>p.Order).First().Position;
        Raylib.DrawText("Space-H8",(int)pos.X-200,(int)pos.Y-200,70,Color.Gold);
        Raylib.DrawText("Main Menu",(int)pos.X,(int)pos.Y-100,50,Color.Gold);
        base.Draw();
    }
}