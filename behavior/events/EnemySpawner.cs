using System.Numerics;
using Asteroid_game.game_objects.factories;
using GameObjects.objects;
using GameObjects.repositories;
using Raylib_cs;

namespace Bevahior;

public class EnemySpawner : GameEvent
{
    private IEnemyFactory _enemyFactory;

    private IGameObjectRepository gameObjectRepository;
    public EnemySpawner(IGameObjectRepository gameObjectRepository, int maxElapsedMilliseconds) : base(maxElapsedMilliseconds)
    {
        this.gameObjectRepository = gameObjectRepository;
        _enemyFactory = new EnemyFactory();
    }

    public override void StartEvent()
    {
        timer.Start();
        if (timer.ElapsedMilliseconds >= MaxElapsedMilliseconds)
        {
            var spawnPosition = CalculateSpawnPosition();
            CreateEnemy(spawnPosition);

            timer.Reset();
        }
    }
    private Vector2 CalculateSpawnPosition()
    {
        Random rnd = new Random();
        var screenWidth = Raylib.GetScreenWidth();
        var screenHeight = Raylib.GetScreenHeight();
        var randomdirection = rnd.Next(1, 3);
        float newx = 0, newy = 0;
        switch (randomdirection)
        {
            case 1:
                //boven 
                newx = rnd.Next((int)gameObjectRepository.Player.X - (screenWidth / 2), (int)gameObjectRepository.Player.X + (screenWidth / 2));
                newy = gameObjectRepository.Player.Y - (screenHeight / 2);
                break;
            case 2:
                //onder 
                newy = gameObjectRepository.Player.Y + (screenHeight / 2);
                break;

        }
        return new Vector2(newx, newy);

    }

    private void CreateEnemy(Vector2 position)
    {
        Random rnd = new Random();
        var randomNumber = rnd.Next(1, gameObjectRepository.CurrentWave + 1);
        var config = gameObjectRepository.EnemyConfgurationData[randomNumber - 1];
        config.TargetPlayer = (Player)gameObjectRepository.Player;
        var enemy = _enemyFactory.Create(config, position);
        gameObjectRepository.AddEntity(enemy);
    }
}