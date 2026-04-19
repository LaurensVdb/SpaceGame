using System.Numerics;
using Behavior.Events;
using GameObjects.Repositories;
using Raylib_cs;
using GameObjects.Factories;

namespace Behavior.Events
{
    public class BulletSpeedItemSpawner : GameEvent
    {
        private IGameObjectRepository _gameObjectRepository;
        private IBulletSpeedItemFactory _bulletSpeedItemFactory;

        public BulletSpeedItemSpawner(IGameObjectRepository gameObjectRepository, int maxElapsedMilliseconds) : base(maxElapsedMilliseconds)
        {
            _bulletSpeedItemFactory = new BulletSpeedItemFactory();
            this._gameObjectRepository = gameObjectRepository;
        }
        public override void StartEvent()
        {
            timer.Start();

            if (timer.ElapsedMilliseconds >= MaxElapsedMilliseconds)
            {
                timer.Reset();
                CreateBulletSpeedItem();
                timer.Start();
            }
        }

        private void CreateBulletSpeedItem()
        {
            var screenWidth = Raylib.GetScreenWidth();
            var screenHeight = Raylib.GetScreenHeight();

            Random rnd = new Random();
            var x = rnd.Next((int)_gameObjectRepository.Player.X - (screenWidth / 2), (int)_gameObjectRepository.Player.X + (screenWidth / 2));
            var y = rnd.Next((int)_gameObjectRepository.Player.Y - (screenHeight / 2), (int)_gameObjectRepository.Player.Y + (screenHeight / 2));
            var position = new Vector2(x, y);

            var bulletSpeedItem = _bulletSpeedItemFactory.Create(position);
            _gameObjectRepository.AddEntity(bulletSpeedItem);
        }
    }
}
