using Game;
using GameState;
using Raylib_cs;

namespace Menu;

public interface IMenuFactory
{
    IGameState Create();
}
public class GameMenuFactory : IMenuFactory
{
    public IGameState Create()
    {
        List<IMenuItem> menuItems =
           [
               new MenuItem("Start",20,Color.Gold,Raylib.GetScreenWidth()/3,Raylib.GetScreenHeight()/2,1,true,new GameWorldFactory().Create()),
                new MenuItem("About",20,Color.Gold,Raylib.GetScreenWidth()/3,(Raylib.GetScreenHeight()/2)+50,2,false,new GameWorldFactory().Create()),
                new MenuItem("Quit",20,Color.Gold,Raylib.GetScreenWidth()/3,(Raylib.GetScreenHeight()/2)+100,3,false,new ExitGame()),

            ];
        return new GameMenu(menuItems);
    }
}
public class GameOverMenuFactory : IMenuFactory
{
    public IGameState Create()
    {
        List<IMenuItem> menuItems =
          [
              new MenuItem("Retry",20,Color.Gold,Raylib.GetScreenWidth()/3,Raylib.GetScreenHeight()/2,1,true,new GameWorldFactory().Create()),
                new MenuItem("Quit",20,Color.Gold,Raylib.GetScreenWidth()/3,(Raylib.GetScreenHeight()/2)+50,2,false,new ExitGame()),

            ];
        return new GameOverMenu(menuItems);
    }
}