using System;
using System.Diagnostics;
using System.Numerics;
using Asteroid_game.drawing;
using Asteroid_game.game_objects.objects;
using Contentmanagement;
using GameObjects.objects;
using GameObjects.repositories;
using MovmementService;
using Raylib_cs;

namespace Asteroid_game.behavior.shooting;

public class PlayerShooting : IShooting
{

    public Stopwatch shootTimer { get; set; }

    public int MaxElapsedMilliseconds { get; set; }

    public PlayerShooting(int maxElapsedMilliseconds)
    {
        this.shootTimer = new Stopwatch();
        MaxElapsedMilliseconds = maxElapsedMilliseconds;
    }

    public Bullet? Shooting(Vector2 position,float rotation)
    {
        shootTimer.Start();
        Bullet? bullet = null;
        if (Raylib.IsMouseButtonDown(MouseButton.Left))
        {
            //schiet
            if (shootTimer.ElapsedMilliseconds > MaxElapsedMilliseconds)
            {
                //var rotatepoint = RotatePoint(new Vector2(position.X, position.Y), new Vector2(position.X, position.Y), entity.Rotation);
                bullet = new Bullet(new BulletMovement(), new BulletDrawing(),
                position.X, position.Y, Contentmanager.Instance.TexturesForTypes[new Tuple<Type, int>(typeof(Bullet), 1)],
                10f, 0, rotation);
                shootTimer.Reset();

            }
        }
        return bullet;
    }

}
