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
    GameOverMenuCreator gameOverMenuCreator = new GameOverMenuCreator();
    GameWorldCreator gameWorldCreator = new GameWorldCreator(); 

    var menu = gameMenuCreator.Create();
    var gameOverMenu = gameOverMenuCreator.Create();
    gameWorldCreator.Create();

    var gameWorld = gameWorldCreator.Create(); 
    GameState.Instance.CurrentGameState = GameStateEnum.Menu;
    while (!WindowShouldClose())
    {
      switch(GameState.Instance.CurrentGameState){
        case GameStateEnum.Playing:
            gameWorld.UpdateWorld();
            BeginDrawing();
            ClearBackground(Color.Black);
            gameWorld.DrawWorld();
            EndDrawing();
          break;
        case GameStateEnum.GameOver:
            gameOverMenu.UpdateMenu();
            BeginDrawing();
            ClearBackground(Color.Black);
            gameOverMenu.DrawStartMenu();
            EndDrawing();
        break;
         case GameStateEnum.Menu:
            menu.UpdateMenu();
            BeginDrawing();
            ClearBackground(Color.Black);
            menu.DrawStartMenu();
            EndDrawing();
        break;
      }


    }

    CloseWindow();
  }
}

