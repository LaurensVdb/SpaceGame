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
    public class ShieldItem : BaseGameEntity, IGameItem
    {
        public ShieldItem(float x, float y, float movementSpeed, int hitPoints, Texture2D texture2D, bool canShoot = false) : base(x, y, movementSpeed, hitPoints, texture2D, canShoot)
        {
        }

        public override void Draw()
        {
            if (this.IsAlive)
                Raylib.DrawTextureV(Texture, new Vector2(X, Y), Color.Yellow);
        }

        public void InteractWithPlayer(IGameEntity player)
        {
            if (player.GetType() == typeof(Player) && this.IsAlive)
            {
                var IsCollision = base.IsCollision(player);
                if (IsCollision)
                {
                    player.ProtectectionLevel = 10;
                    IsAlive = false;

                }
            }
        }
    }
}
