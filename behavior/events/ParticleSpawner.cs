using ContentManagement;
using GameObjects.Objects;
using GameObjects.Repositories;
using Behavior.Movement;
using Raylib_cs;
using Drawing;

namespace Behavior.Events;

public class ParticleSpawner : GameEvent
{

    private IGameObjectRepository gameObjectRepository;
    public ParticleSpawner(IGameObjectRepository gameObjectRepository, int maxElapsedMilliseconds) : base(maxElapsedMilliseconds)
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
            gameObjectRepository.Entities.Add(new Star(new StarMovement(), new StarDrawing(),
              rnd.Next((int)gameObjectRepository.Player.X - (screenWidth), (int)gameObjectRepository.Player.X + (screenWidth)),
            rnd.Next((int)gameObjectRepository.Player.Y - (screenHeight), (int)gameObjectRepository.Player.Y + (screenHeight)),
            0.5f, Contentmanager.Instance.TexturesForTypes[new Tuple<Type, int>(typeof(Star), rnd.Next(1, 3))]
      ));
            timer.Start();
        }
    }
}