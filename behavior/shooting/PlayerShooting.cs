using System;
using System.Diagnostics;
using System.Numerics;
using Drawing;
using GameObjects.Objects;
using ContentManagement;
using GameObjects.Repositories;
using Behavior.Movement;
using Raylib_cs;

namespace Behavior.Shooting;

public class PlayerShooting : IShooting
{

    public Stopwatch shootTimer { get; set; }

    public int MaxElapsedMilliseconds { get; set; }

    public PlayerShooting(int maxElapsedMilliseconds)
    {
        this.shootTimer = new Stopwatch();
        MaxElapsedMilliseconds = maxElapsedMilliseconds;
    }

    public Bullet? Shooting(Vector2 position, float rotation)
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
                rotation);

                bullet.MovementSpeed = 10f;
                shootTimer.Reset();

            }
        }
        return bullet;
    }

}
