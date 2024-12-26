using GameObjects.objects;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Asteroid_game.game_objects.objects
{
    public class BulletSpeedItem : BaseGameEntity, IGameItem
    {
        public BulletSpeedItem(float x, float y, float movementSpeed, int hitPoints, Texture2D texture2D, bool canShoot = false) : base(x, y, movementSpeed, hitPoints, texture2D, canShoot)
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
            if (player.GetType() == typeof(Player) && this.IsAlive)
            {
                var IsCollision = base.IsCollision(player);
                if (IsCollision)
                {
                    player.MaxElapsedMillisecondsShootingTime = 0;
                    IsAlive = false;
                    _=Delayedtask(player);
                }
            }
        }
    }
}
