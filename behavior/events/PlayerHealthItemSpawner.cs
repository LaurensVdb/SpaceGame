using System.Numerics;
using Bevahior;
using GameObjects.repositories;
using Raylib_cs;
using Asteroid_game.game_objects.factories;

namespace Events.behavior
{
    public class PlayerHealtItemSpawner : GameEvent
    {
        private IGameObjectRepository _gameObjectRepository;
        private IHealtItemFactory _healthItemFactory;
        public PlayerHealtItemSpawner(IGameObjectRepository gameObjectRepository, int maxElapsedMilliseconds) : base(maxElapsedMilliseconds)
        {
            _healthItemFactory = new HealtItemFactory();
            this._gameObjectRepository = gameObjectRepository;
        }
        public override void StartEvent()
        {
            timer.Start();
            if (timer.ElapsedMilliseconds >= MaxElapsedMilliseconds)
            {
                timer.Reset();
                CreateHealthItem();
                timer.Start();
            }
        }

        private void CreateHealthItem()
        {
            var screenWidth = Raylib.GetScreenWidth();
            var screenHeight = Raylib.GetScreenHeight();

            Random rnd = new Random();
            var x = rnd.Next((int)_gameObjectRepository.Player.X - (screenWidth / 2), (int)_gameObjectRepository.Player.X + (screenWidth / 2));
            var y = rnd.Next((int)_gameObjectRepository.Player.Y - (screenHeight / 2), (int)_gameObjectRepository.Player.Y + (screenHeight / 2));
            var posistion = new Vector2(x, y);

            var healthItem = _healthItemFactory.Create(posistion);
            _gameObjectRepository.AddEntity(healthItem);
        }
    }
}
