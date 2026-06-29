using Drawing;
using Behavior.Movement;
using Raylib_cs;

namespace GameObjects.Objects;

public class Star : BaseGameEntity, IMovableEntity
{
    private readonly IMovement movementservice;

    public Star(IMovement movementservice, IDrawing drawing, float x, float y, float movementSpeed, int hitPoints, Texture2D texture) : base(drawing, x, y, movementSpeed, hitPoints, texture)
    {
        this.movementservice = movementservice;
    }

    public void Move()
    {
        this.movementservice.Move(this);
    }
}