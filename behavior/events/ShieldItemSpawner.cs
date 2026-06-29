using System.Numerics;
using GameObjects.Factories;
using Behavior.Events;
using GameObjects.Repositories;
using Raylib_cs;
using GameObjects.Objects;

namespace Behavior.Events
{
    public class ShieldItemSpawner : GameEvent
    {
        private IGameObjectRepository _gameObjectRepository;
        private IShieldItemFactory _shieldItemFactory;
        public ShieldItemSpawner(IGameObjectRepository gameObjectRepository, int maxElapsedMilliseconds) : base(maxElapsedMilliseconds)
        {

            this._gameObjectRepository = gameObjectRepository;
            _shieldItemFactory = new ShieldItemFactory();
        }
        public override void StartEvent()
        {
            timer.Start();

            var playerProtectionLevel = ((IDamageableEntity)_gameObjectRepository.Player).ProtectectionLevel;
            if (timer.ElapsedMilliseconds >= MaxElapsedMilliseconds && playerProtectionLevel < 10)
            {
                timer.Reset();
                CreateShieldItem();
                timer.Start();
            }
        }

        private void CreateShieldItem()
        {
            var screenWidth = Raylib.GetScreenWidth();
            var screenHeight = Raylib.GetScreenHeight();

            Random rnd = new Random();
            var x = rnd.Next((int)_gameObjectRepository.Player.X - (screenWidth / 2), (int)_gameObjectRepository.Player.X + (screenWidth / 2));
            var y = rnd.Next((int)_gameObjectRepository.Player.Y - (screenHeight / 2), (int)_gameObjectRepository.Player.Y + (screenHeight / 2));
            var position = new Vector2(x, y);

            var shieldItem = _shieldItemFactory.Create(position);
            _gameObjectRepository.AddEntity(shieldItem);
        }
    }
}
