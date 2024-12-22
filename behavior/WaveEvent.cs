using GameObjects.repositories;
using Raylib_cs;

namespace Bevahior
{
    public class WaveEvent : GameEvent
    {
        private int maxElapsedMillisecondsPause = 15000;
        private IGameObjectRepository gameObjectRepository;
     
        EnemySpawner spawner;


        private int maxEnemies = 4;
        private bool currentWaveIsActive = true;

        bool isRunning => maxEnemies > gameObjectRepository.TotalEnemiesSpawned;
        public WaveEvent(IGameObjectRepository gameObjectRepository)
        {
            this.gameObjectRepository = gameObjectRepository;
            spawner = new EnemySpawner(gameObjectRepository);
            currentWaveIsActive = true;
            gameObjectRepository.CurrentWave = 1;
        }


        public override void StartEvent()
        {
            if (currentWaveIsActive)
            {
                if (isRunning)
                {
                    spawner.StartEvent();
                }
                else
                {
                    if (gameObjectRepository.Player.KillCount >= maxEnemies)
                    {
                        currentWaveIsActive = false;
                    }
                }
            }
            else
            {
                timer.Start();

                if(timer.ElapsedMilliseconds >= maxElapsedMillisecondsPause)
                {
                    currentWaveIsActive = true;
                    gameObjectRepository.CurrentWave++;
                    maxEnemies = maxEnemies * gameObjectRepository.CurrentWave;
                    gameObjectRepository.Player.KillCount = 0;
                    gameObjectRepository.TotalEnemiesSpawned = 0; 
                 
                    timer.Reset();

                }
            }
          
        }

        public override void Draw()
        {
            if (currentWaveIsActive)
            {
                Raylib.DrawText($"Current wave: {gameObjectRepository.CurrentWave}", 20, 80, 20, Color.Gold);

            }
            else
            {
                var elapsedTime = (maxElapsedMillisecondsPause - timer.ElapsedMilliseconds) / 1000;
                Raylib.DrawText($"pause: {elapsedTime}", 20, 80, 20, Color.Gold);
            }
         
             
            
        }
    }
}
