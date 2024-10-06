using System;
using bevahior;
using GameObjects.repositories;

namespace Asteroid_game.behavior;

public class PlayerShootEvent : GameEvent
{
    private IGameObjectRepository gameObjectRepository;
    public PlayerShootEvent(IGameObjectRepository gameObjectRepository)
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
       
    }
}
