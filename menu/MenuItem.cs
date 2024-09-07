using Raylib_cs;
using GameStateBevahior;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
namespace GameMenuBevahior;

public sealed class MenuItem(IGameState gameState,string title,int fontSize,Color color,int x,int y,int order,bool isSelected,GameStateEnum gameStateEnum) : IMenuItem {
    public string Title=>title;
    public bool IsSelected { get=>isSelected; set=>isSelected=value; }
    public int FontSize {get{
      if(IsSelected)
        return fontSize *2;
      
      return fontSize;

    }
    }
    public Color Color =>color;
    public int X =>x;
    public int Y =>y;
    public  int Order {get=>order;}
    public GameStateEnum GameState=>gameStateEnum;
    public void DrawMenuItem(){
            Raylib.DrawText(Title,X,Y,FontSize,Color);
    }
    public Vector2 Position {get=>new Vector2(x,y);}
    public void SelectMenuItem(){
      gameState.CurrentGameState = gameStateEnum;
    }

}