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
        if(timer.ElapsedMilliseconds>=500) {
                  timer.Reset(); 
                  Random rnd = new Random();
                  gameObjectRepository.Entities.Add( new Star(rnd.Next((int)gameObjectRepository.Player.X - (screenWidth/2),(int)gameObjectRepository.Player.X + (screenWidth/2)),
                  (int)gameObjectRepository.Player.Y,5,5,0.02f,0));
                  timer.Start(); 
        }
    }
}