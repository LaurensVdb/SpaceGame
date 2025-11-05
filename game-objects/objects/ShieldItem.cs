using GameObjects.objects;
using MovmementService;
using Raylib_cs;
using System.Numerics;

namespace Asteroid_game.game_objects.objects
{
    public class ShieldItem : BaseGameEntity, IGameItem
    {
        public ShieldItem(IMovement movementservice, float x, float y, float movementSpeed, int hitPoints, Texture2D texture2D, bool canShoot = false)
            : base(movementservice, x, y, movementSpeed, hitPoints, texture2D, canShoot)
        {
        }

        public override void Draw()
        {
            if (this.IsAlive)
                Raylib.DrawTextureV(Texture, new Vector2(X, Y), Color.Yellow);
        }

        public void InteractWithPlayer(IGameEntity player)
        {
            player.ProtectectionLevel = 10;
            IsAlive = false;
        }
    }
}
