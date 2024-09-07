using System.Diagnostics;
using GameStateBevahior;
using Microsoft.VisualBasic;
using Raylib_cs;

namespace Game;

public class ExitGame : IGameState
{
    private Stopwatch timer;
    public ExitGame()
    {
        timer=new Stopwatch(); 
        timer.Start();
    }
    public void Draw()
    {
       Raylib.DrawText("by bye spacemarine! closing the game...",Raylib.GetScreenWidth()/3,Raylib.GetScreenHeight()/3,20,Color.Gold);
    }


    public void Update(GameStateManager gameStateManager)
    {
          if(timer.ElapsedMilliseconds>=3000) { 
            gameStateManager.IsExit=true;
          }
    }
}