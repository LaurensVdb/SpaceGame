using Asteroid_game.drawing;
using MovmementService;
using Raylib_cs;

namespace GameObjects.objects;

public class Star : BaseGameEntity
{


    public Star(IMovement movementservice, IDrawing drawing, float x, float y, float movementSpeed, int hitPoints, Texture2D texture) : base(movementservice, drawing, x, y, movementSpeed, hitPoints, texture)
    {

    }

}