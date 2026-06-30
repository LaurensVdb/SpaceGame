using System;
using System.Diagnostics;
using System.Numerics;
using Drawing;
using GameObjects.Objects;
using ContentManagement;
using GameObjects.Repositories;
using Behavior.Movement;

namespace Behavior.Shooting;

public class EnemyDefaultShooting : IShooting
{


    public Stopwatch shootTimer { get; set; }
    public int MaxElapsedMilliseconds { get; set; }

    public EnemyDefaultShooting(int maxElapsedMilliseconds)
    {
        MaxElapsedMilliseconds = maxElapsedMilliseconds;
        this.shootTimer = new Stopwatch();
    }

    public Bullet? Shooting(Vector2 position, float rotatepoint)
    {

        shootTimer.Start();
        Bullet? bullet = null;
        if (shootTimer.ElapsedMilliseconds >= MaxElapsedMilliseconds)
        {

            bullet = new Bullet(new BulletMovement(), new BulletDrawing(),
            position.X, position.Y, Contentmanager.Instance.TexturesForTypes[new Tuple<Type, int>(typeof(Bullet), 1)], rotatepoint, true);
            bullet.MovementSpeed = 10f;
            shootTimer.Reset();


        }
        return bullet;
    }
}
