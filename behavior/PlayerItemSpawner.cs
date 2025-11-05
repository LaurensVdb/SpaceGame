using Asteroid_game.behavior.movement;
using Asteroid_game.game_objects.objects;
using Bevahior;
using Contentmanagement;
using GameObjects.repositories;
using Raylib_cs;

namespace Asteroid_game.behavior
{
    public class PlayerItemSpawner : GameEvent
    {
        private IGameObjectRepository gameObjectRepository;

        public PlayerItemSpawner(IGameObjectRepository gameObjectRepository, int maxElapsedMilliseconds) : base(maxElapsedMilliseconds)
        {

            this.gameObjectRepository = gameObjectRepository;
        }
        public override void StartEvent()
        {
            var screenWidth = Raylib.GetScreenWidth();
            var screenHeight = Raylib.GetScreenHeight();
            timer.Start();
            if (timer.ElapsedMilliseconds >= MaxElapsedMilliseconds)
            {
                timer.Reset();
                Random rnd = new Random();
                gameObjectRepository.AddEntity(new HealthItem(new NoMovement(),
                  rnd.Next((int)gameObjectRepository.Player.X - (screenWidth / 2), (int)gameObjectRepository.Player.X + (screenWidth / 2)),
                rnd.Next((int)gameObjectRepository.Player.Y - (screenHeight / 2), (int)gameObjectRepository.Player.Y + (screenHeight / 2)),
                0.5f, 0, Contentmanager.Instance.TexturesForTypes[new Tuple<Type, int>(typeof(HealthItem), 1)]
          ));
                timer.Start();
            }
        }
    }
}
