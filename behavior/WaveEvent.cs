using GameObjects.repositories;

namespace Bevahior
{
    public class WaveEvent : GameEvent
    {
        private const int standardWaveLength= 30000;//30 seconds
        private IGameObjectRepository gameObjectRepository;
        public WaveEvent(IGameObjectRepository gameObjectRepository)
        {
            this.gameObjectRepository = gameObjectRepository;
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
        
            timer.Start();
            if (timer.ElapsedMilliseconds >= (standardWaveLength * gameObjectRepository.CurrentWave))
            {
                gameObjectRepository.CurrentWave++;
                timer.Reset();
              
                timer.Start();
            }
        }
    }
}
