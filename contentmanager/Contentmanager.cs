using GameObjects;
using Raylib_cs;

namespace Contentmanagement;

public  class Contentmanager {

    private static readonly Contentmanager instance = new Contentmanager();
    static Contentmanager()
    {
    }
   
    public static Contentmanager Instance
    {
        get
        {
            return instance;
        }
    }

    public Dictionary<Tuple<Type,int>,Texture2D> TexturesForTypes = new Dictionary<Tuple<Type,int>, Texture2D>();
    private Contentmanager()
    {
 
        TexturesForTypes.Add(new Tuple<Type, int>(typeof(Player),1),Raylib.LoadTexture("sprites/player.png"));
        TexturesForTypes.Add(new Tuple<Type, int>(typeof(Enemy),1),Raylib.LoadTexture("sprites/enemy1.png"));
        TexturesForTypes.Add(new Tuple<Type, int>(typeof(Enemy),2),Raylib.LoadTexture("sprites/enemy2.png"));
        TexturesForTypes.Add(new Tuple<Type, int>(typeof(Enemy),3),Raylib.LoadTexture("sprites/enemy3.png"));
      
    }
}