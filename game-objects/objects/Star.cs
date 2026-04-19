using Drawing;
using Behavior.Movement;
using Raylib_cs;

namespace GameObjects.Objects;

public class Star : BaseGameEntity
{


    public Star(IMovement movementservice, IDrawing drawing, float x, float y, float movementSpeed, int hitPoints, Texture2D texture) : base(movementservice, drawing, x, y, movementSpeed, hitPoints, texture)
    {

    }

}