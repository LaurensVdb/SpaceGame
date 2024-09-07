using GameStateBevahior;
using Raylib_cs;

namespace GameMenuBevahior;

public abstract class MenuFactory{
    public abstract IMenu Create();
}
public class GameMenuCreator : MenuFactory
{
    public override IMenu Create()
    {
         List<IMenuItem> menuItems =
            [
                new MenuItem(GameState.Instance,"Start",20,Color.Gold,Raylib.GetScreenWidth()/3,Raylib.GetScreenHeight()/2,1,true,GameStateEnum.Playing),
                new MenuItem(GameState.Instance,"Quit",20,Color.Gold,Raylib.GetScreenWidth()/3,(Raylib.GetScreenHeight()/2)+50,2,false,GameStateEnum.Quit),
              
            ]; 
        return new GameMenu(GameState.Instance,menuItems);
    }
}
public class GameOverMenuCreator : MenuFactory
{
    public override IMenu Create()
    {
          List<IMenuItem> menuItems =
            [
                new MenuItem(GameState.Instance,"Retry",20,Color.Gold,Raylib.GetScreenWidth()/3,Raylib.GetScreenHeight()/2,1,true,GameStateEnum.Playing),
                new MenuItem(GameState.Instance,"Quit",20,Color.Gold,Raylib.GetScreenWidth()/3,(Raylib.GetScreenHeight()/2)+50,2,false,GameStateEnum.Quit),
              
            ]; 
       return new GameOverMenu(GameState.Instance,menuItems);
    }
}