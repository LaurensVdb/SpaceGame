using GameStateBevahior;
using Raylib_cs;

namespace GameMenuBevahior;
public  class BaseMenu (List<IMenuItem>menuItems) : IGameState{

    public List<IMenuItem> MenuItems { get=>menuItems; set=>menuItems=value; }
    protected int currentMenuOrder=1;

   

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
    public virtual void Update(GameStateManager gameStateManager){
        GameWorldCreator gameWorldCreator =new GameWorldCreator(); 

        if(Raylib.IsKeyPressed(KeyboardKey.Up)){
           checkMenuItemSelected(-1);
        }
        if(Raylib.IsKeyPressed(KeyboardKey.Down)){
            checkMenuItemSelected(+1);
        }
        if(Raylib.IsKeyPressed(KeyboardKey.Enter)){
             var item = menuItems.First(p=>p.Order==currentMenuOrder);
            gameStateManager.State = item.GameState;
            
             
        }

    }
    public virtual void Draw(){
        foreach(var item in menuItems.OrderBy(p=>p.Order)){
              item.DrawMenuItem();
        }
      
    }

}