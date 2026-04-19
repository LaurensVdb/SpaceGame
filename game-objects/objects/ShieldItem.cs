using Drawing;
using GameObjects.Objects;
using Behavior.Movement;
using Raylib_cs;

namespace GameObjects.Objects
{
    public class ShieldItem : BaseGameEntity, IGameItem
    {
        public ShieldItem(IMovement movementservice, IDrawing drawing, float x, float y, float movementSpeed, int hitPoints, Texture2D texture2D)
            : base(movementservice, drawing, x, y, movementSpeed, hitPoints, texture2D)
        {
        }


        public void InteractWithPlayer(Player player)
        {
            player.ProtectectionLevel = 10;
            IsAlive = false;
        }
    }
}
