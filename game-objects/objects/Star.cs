using MovmementService;
using Raylib_cs;
using System.Numerics;

namespace GameObjects.objects;

public class Star : BaseGameEntity
{


    public Star(IMovement movementservice, float x, float y, float movementSpeed, int hitPoints, Texture2D texture) : base(movementservice, x, y, movementSpeed, hitPoints, texture)
    {

    }
    public override void Draw()
    {
        Raylib.DrawTextureEx(Texture, new Vector2(X, Y), 0f, 0.2f, Color.White);
    }

}