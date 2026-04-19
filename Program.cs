using Menu;
using GameState;
using Raylib_cs;
using static Raylib_cs.Raylib;


class Program
{
  public static void Main()
  {
    InitWindow(1920, 1080, "space adventure");

    //ToggleFullscreen();
    SetTargetFPS(60);


    //HideCursor();
    GameMenuFactory gameMenuCreator = new GameMenuFactory();


    var menu = gameMenuCreator.Create();
    GameStateManager gameStateManager = new GameStateManager(menu);
    gameStateManager.Update();

  }
}

