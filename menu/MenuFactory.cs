using GameStateBevahior;
using Raylib_cs;

namespace GameMenuBevahior;

public abstract class MenuFactory{
    public abstract IGameState Create();
}
public class GameMenuCreator : MenuFactory
{
    public override IGameState Create()
    {
         List<IMenuItem> menuItems =
            [
                new MenuItem("Start",20,Color.Gold,Raylib.GetScreenWidth()/3,Raylib.GetScreenHeight()/2,1,true,new GameWorldCreator().Create()),
                new MenuItem("About",20,Color.Gold,Raylib.GetScreenWidth()/3,(Raylib.GetScreenHeight()/2)+50,2,false,new GameWorldCreator().Create()),
                new MenuItem("Quit",20,Color.Gold,Raylib.GetScreenWidth()/3,(Raylib.GetScreenHeight()/2)+100,3,false,new GameWorldCreator().Create()),
              
            ]; 
        return new GameMenu(menuItems);
    }
}
public class GameOverMenuCreator : MenuFactory
{
    public override IGameState Create()
    {
          List<IMenuItem> menuItems =
            [
                new MenuItem("Retry",20,Color.Gold,Raylib.GetScreenWidth()/3,Raylib.GetScreenHeight()/2,1,true,new GameWorldCreator().Create()),
                new MenuItem("Quit",20,Color.Gold,Raylib.GetScreenWidth()/3,(Raylib.GetScreenHeight()/2)+50,2,false,new GameWorldCreator().Create()),
              
            ]; 
       return new GameOverMenu(menuItems);
    }
}