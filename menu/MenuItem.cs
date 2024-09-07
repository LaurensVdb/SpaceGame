using Raylib_cs;
using GameStateBevahior;
using System.Numerics;
namespace GameMenuBevahior;

public sealed class MenuItem(string title,int fontSize,Color color,int x,int y,int order,bool isSelected,IGameState gameState) : IMenuItem {
    public string Title{
      get{
        var endtag = '>';
        var begintag ='<';
        if(IsSelected){
            return begintag + " " + title + " " + endtag;
        }
        return title;
      }
    }
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
    public IGameState GameState=>gameState;
    public void DrawMenuItem(){
            Raylib.DrawText(Title,X,Y,FontSize,Color);
    }
    public Vector2 Position {get=>new Vector2(x,y);}


}