using Asteroid_game.behavior.movement;
using Asteroid_game.game_objects.objects;
using Bevahior;
using Contentmanagement;
using GameObjects.repositories;
using Raylib_cs;

namespace Asteroid_game.behavior
{
    public class ShieldItemSpawner : GameEvent
    {
        private IGameObjectRepository gameObjectRepository;

        public ShieldItemSpawner(IGameObjectRepository gameObjectRepository, int maxElapsedMilliseconds) : base(maxElapsedMilliseconds)
        {

            this.gameObjectRepository = gameObjectRepository;
        }
        public override void StartEvent()
        {
            var screenWidth = Raylib.GetScreenWidth();
            var screenHeight = Raylib.GetScreenHeight();
            timer.Start();

            var playerProtectionLevel = gameObjectRepository.Player.ProtectectionLevel;
            if (timer.ElapsedMilliseconds >= MaxElapsedMilliseconds && playerProtectionLevel < 10)
            {
                timer.Reset();
                Random rnd = new Random();
                gameObjectRepository.AddEntity(new ShieldItem(new NoMovement(),
                  rnd.Next((int)gameObjectRepository.Player.X - (screenWidth / 2), (int)gameObjectRepository.Player.X + (screenWidth / 2)),
                rnd.Next((int)gameObjectRepository.Player.Y - (screenHeight / 2), (int)gameObjectRepository.Player.Y + (screenHeight / 2)),
                0.5f, 0, Contentmanager.Instance.TexturesForTypes[new Tuple<Type, int>(typeof(ShieldItem), 1)]
          ));
                timer.Start();
            }
        }
    }
}
