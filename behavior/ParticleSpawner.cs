using System.Diagnostics;
using GameObjects.objects;
using GameObjects.repositories;

namespace Bevahior;

public class ParticleSpawner:IParticleSpawner{
    private Stopwatch timer;
    public ParticleSpawner()
    {
        timer = new Stopwatch();
    }

    public void StartParticleSpawner(int screenWidth , int screenHeight,IGameObjectRepository gameObjectRepository){
        timer.Start();
        if(timer.ElapsedMilliseconds>=200) {
                  timer.Reset(); 
                  Random rnd = new Random();
                  gameObjectRepository.Entities.Add( new Star(rnd.Next((int)gameObjectRepository.Player.X - (screenWidth),(int)gameObjectRepository.Player.X + (screenWidth)),
                  rnd.Next((int)gameObjectRepository.Player.Y - (screenHeight),(int)gameObjectRepository.Player.Y + (screenHeight)),5,5,0.02f,0));
                  timer.Start(); 
        }
    }
}