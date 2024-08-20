
using System.Diagnostics;
using System.Numerics;
using Bevahior;
using Camera;
using Contentmanagement;
using GameObjects;
using Raylib_cs;
using static Raylib_cs.Raylib;
  

  class Program {
    public static void Main(){
        InitWindow(1920, 1080, "space adventure");
          /* 
          Laad content eerst ! voor betere resource beheer
          */
        ToggleFullscreen();
          //HideCursor();
        Player player = new Player(1920/2,1080/2,5f,3,Contentmanager.Instance.TexturesForTypes[new Tuple<Type, int>(typeof(Player),1)]);

        GameWorld gameWorld = new(new GameObjectRepository(player),new GameCamera(),new EnemySpawner(),new ParticleSpawner(),1920,1080);
        SetTargetFPS(60);
        while (!WindowShouldClose())
        {
            gameWorld.UpdateWorld();
            BeginDrawing();
            ClearBackground(Color.Black);
            gameWorld.DrawWorld();
            EndDrawing();
        }

            CloseWindow();
}
  }

