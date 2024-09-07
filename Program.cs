using GameMenuBevahior;
using GameStateBevahior;
using Raylib_cs;
using static Raylib_cs.Raylib;


class Program
{
  public static void Main()
  {
    InitWindow(1920, 1080, "space adventure");
 
    ToggleFullscreen();
    SetTargetFPS(60);


    //HideCursor();
    GameMenuCreator gameMenuCreator = new GameMenuCreator(); 


    var menu = gameMenuCreator.Create();
    GameStateManager gameStateManager = new GameStateManager(menu); 
    gameStateManager.Update();

  }
}

