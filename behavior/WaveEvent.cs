using GameObjects.repositories;

namespace Bevahior
{
    public class WaveEvent : GameEvent
    {

        private IGameObjectRepository gameObjectRepository;

        EnemySpawner spawner;


        private int maxEnemies = 4;
        private bool currentWaveIsActive = true;

        bool isRunning => maxEnemies > gameObjectRepository.TotalEnemiesSpawned;
        public WaveEvent(IGameObjectRepository gameObjectRepository, int maxElapsedMillisecondsPause) : base(maxElapsedMillisecondsPause)
        {
            this.gameObjectRepository = gameObjectRepository;
            spawner = new EnemySpawner(gameObjectRepository, 500);
            currentWaveIsActive = true;
            gameObjectRepository.CurrentWave = 1;
        }

        public bool CurrentWaveIsActive => currentWaveIsActive;
        public IGameObjectRepository Repository => gameObjectRepository;
        public int MaxPauseMilliseconds => MaxElapsedMilliseconds;
        public long TimerElapsedMilliseconds => timer.ElapsedMilliseconds;


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

                if (timer.ElapsedMilliseconds >= MaxElapsedMilliseconds)
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
    }
}
