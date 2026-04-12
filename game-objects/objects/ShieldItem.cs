using Asteroid_game.drawing;
using GameObjects.objects;
using MovmementService;
using Raylib_cs;

namespace Asteroid_game.game_objects.objects
{
    public class ShieldItem : BaseGameEntity, IGameItem
    {
        public ShieldItem(IMovement movementservice, IDrawing drawing, float x, float y, float movementSpeed, int hitPoints, Texture2D texture2D)
            : base(movementservice, drawing, x, y, movementSpeed, hitPoints, texture2D)
        {
        }


        public void InteractWithPlayer(BaseGameEntity player)
        {
            player.ProtectectionLevel = 10;
            IsAlive = false;
        }
    }
}
