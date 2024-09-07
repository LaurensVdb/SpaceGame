using Bevahior;
using Camera;
using Game;
using GameObjects.factories;
using GameObjects.repositories;
using GameStateBevahior;

public abstract class GameWorldFactory{
    public abstract IGameWorld Create();
}