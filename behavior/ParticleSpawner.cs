using System.Diagnostics;
using bevahior;
using Contentmanagement;
using GameObjects.objects;
using GameObjects.repositories;
using Raylib_cs;

namespace Bevahior;

public class ParticleSpawner: GameEvent{
  
    private IGameObjectRepository gameObjectRepository;
    public ParticleSpawner(IGameObjectRepository gameObjectRepository)
    {
       this.gameObjectRepository=gameObjectRepository;
    }

    public override void EndEvent()
    {
        throw new NotImplementedException();
    }

    public override void PauseEvent()
    {
        throw new NotImplementedException();
    }

    public override void StartEvent()
    {
        var screenWidth = Raylib.GetScreenWidth(); 
        var screenHeight = Raylib.GetScreenHeight(); 
        timer.Start();
        if(timer.ElapsedMilliseconds>=200) {
                  timer.Reset(); 
                  Random rnd = new Random();
                  gameObjectRepository.Entities.Add( new Star(
                    rnd.Next((int)gameObjectRepository.Player.X - (screenWidth),(int)gameObjectRepository.Player.X + (screenWidth)),
                  rnd.Next((int)gameObjectRepository.Player.Y - (screenHeight),(int)gameObjectRepository.Player.Y + (screenHeight)),
                  0.5f,0,Contentmanager.Instance.TexturesForTypes[new Tuple<Type, int>(typeof(Star), rnd.Next(1,3))]
            ));
                  timer.Start(); 
        }
    }
}