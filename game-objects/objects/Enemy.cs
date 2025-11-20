using Asteroid_game.drawing;
using Contentmanagement;
using GameObjects.repositories;
using MovmementService;
using Raylib_cs;
using System.Diagnostics;

namespace GameObjects.objects;



public class Enemy : BaseGameEntity
{
    private Stopwatch timer;

    //public override Rectangle CollisionRectangle => new Rectangle(X, Y, Widht, Height);

    public Enemy(IMovement movementservice, IDrawing drawing, float x, float y, float movementSpeed, int hitPoints, Texture2D texture2D, bool canShoot = false) : base(movementservice, drawing, x, y, movementSpeed, hitPoints, texture2D, canShoot)
    {

        timer = new Stopwatch();
        timer.Start();
        if (canShoot)
            MaxElapsedMillisecondsShootingTime = 2000;
    }


    public override void Shoot(IGameObjectRepository gameObjectRepository)
    {
        var deltaX = gameObjectRepository.Player.X - X;
        var deltaY = gameObjectRepository.Player.Y - Y;
        var playerrotation = MathF.Atan2(deltaY, deltaX) * (180f / MathF.PI) + 90;
        if (timer.ElapsedMilliseconds >= MaxElapsedMillisecondsShootingTime)
        {
            timer.Reset();
            gameObjectRepository.AddEntity(new Bullet(new BulletMovement(), new BulletDrawing(), X, Y, Contentmanager.Instance.TexturesForTypes[new Tuple<Type, int>(typeof(Bullet), 1)], 10f, 0, playerrotation, true));
            timer.Start();
        }

    }

}