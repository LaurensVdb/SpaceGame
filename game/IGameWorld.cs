using bevahior;
using Bevahior;
using Camera;
using GameObjects.factories;
using GameObjects.repositories;

namespace Game;

public interface IGameWorld{
    IGameObjectRepository GameObjectRepository { get; set; }
    IGameCamera GameCamera { get; set; }
    List<IGameEvent> GameEvents{get;set;}

    int ScreenWidth{get;}
    int ScreenHeight{get;}
}