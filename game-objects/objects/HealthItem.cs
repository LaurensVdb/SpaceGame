using Drawing;
using GameObjects.Objects;
using Behavior.Movement;
using Raylib_cs;

namespace GameObjects.Objects
{
    public class HealthItem : BaseGameEntity, IGameItem
    {
        public HealthItem(IDrawing drawing, float x, float y, float movementSpeed, int hitPoints, Texture2D texture2D)
            : base(drawing, x, y, movementSpeed, hitPoints, texture2D)
        {
        }

        public void InteractWithPlayer(Player player)
        {
            player.HitPoints++;
            this.IsAlive = false;

        }
    }
}
