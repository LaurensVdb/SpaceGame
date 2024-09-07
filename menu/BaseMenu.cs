using GameStateBevahior;
using Raylib_cs;

namespace GameMenuBevahior;
public  class BaseMenu (IGameState gameState ,List<IMenuItem>menuItems) : IMenu{

    public List<IMenuItem> MenuItems { get=>menuItems; set=>menuItems=value; }
    protected int currentMenuOrder=1;

    public IGameState GameState { get; } = gameState;

    private void checkMenuItemSelected(int currentIndex){
        menuItems.ForEach(p=>p.IsSelected=false);

        currentMenuOrder +=currentIndex;
        if(currentMenuOrder>menuItems.Count())
            currentMenuOrder=1;
        if(currentMenuOrder<=0)
            currentMenuOrder=menuItems.Count();

         var item = menuItems.First(p=>p.Order==currentMenuOrder);
        item.IsSelected=true;
       
    }
    public virtual void UpdateMenu(){


        if(Raylib.IsKeyPressed(KeyboardKey.Up)){
           checkMenuItemSelected(1);
        }
        if(Raylib.IsKeyPressed(KeyboardKey.Down)){
            checkMenuItemSelected(-1);
        }
        if(Raylib.IsKeyPressed(KeyboardKey.Enter)){
             menuItems.First(p=>p.Order==currentMenuOrder).SelectMenuItem();
        }

    }
    public virtual void DrawStartMenu(){
        foreach(var item in menuItems.OrderBy(p=>p.Order)){
              item.DrawMenuItem();
        }
      
    }

}