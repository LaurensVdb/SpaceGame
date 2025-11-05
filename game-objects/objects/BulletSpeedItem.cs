using GameObjects.objects;
using MovmementService;
using Raylib_cs;
using System.Numerics;

namespace Asteroid_game.game_objects.objects
{
    public class BulletSpeedItem : BaseGameEntity, IGameItem
    {
        public BulletSpeedItem(IMovement movementservice, float x, float y, float movementSpeed, int hitPoints, Texture2D texture2D, bool canShoot = false)
            : base(movementservice, x, y, movementSpeed, hitPoints, texture2D, canShoot)
        {
        }

        public override void Draw()
        {
            if (this.IsAlive)
                Raylib.DrawTextureV(Texture, new Vector2(X, Y), Color.Yellow);
        }

        private async Task Delayedtask(IGameEntity gameEntity)
        {
            await Task.Delay(10000);
            gameEntity.MaxElapsedMillisecondsShootingTime = 100;

        }
        public void InteractWithPlayer(IGameEntity player)
        {

            player.MaxElapsedMillisecondsShootingTime = 0;
            IsAlive = false;
            _ = Delayedtask(player);

        }
    }
}
