using Asteroid_game.behavior.collision;
using Asteroid_game.behavior.movement;
using Bevahior;
using Camera;
using GameMenuBevahior;
using GameObjects.factories;
using GameObjects.repositories;
using GameStateBevahior;
using Raylib_cs;
namespace Game;

public sealed class GameWorld : IGameState, IGameWorld
{
    public IGameObjectRepository GameObjectRepository { get; set; }
    public IGameCamera GameCamera { get; set; }
    private PlayerFactory playerFactory;

    public int ScreenWidth { get { return Raylib.GetScreenWidth(); } }
    public int ScreenHeight { get { return Raylib.GetScreenHeight(); } }
    public List<IGameEvent> GameEvents { get; set; }

    private readonly ICollisionDetectionService _collisionDetectionService;
    private readonly IMovementService _movementService;
    public GameWorld(IGameObjectRepository gameObjectRepository, IGameCamera camera, ICollisionDetectionService collisionDetectionService, IMovementService movementService, List<IGameEvent> gameEvents)
    {
        this.GameObjectRepository = gameObjectRepository;
        this.GameCamera = camera;
        this.GameEvents = gameEvents;
        playerFactory = new PlayerFactory();
        _collisionDetectionService = collisionDetectionService;
        _movementService = movementService;
        CreateCameraForPlayer();

    }

    private void CreateCameraForPlayer()
    {

        GameObjectRepository.SetPlayer(playerFactory.FactoryMethod());
        GameCamera.CreateCamera(GameObjectRepository.Player, ScreenWidth, ScreenHeight);
    }
    private void StickCameraToplayer()
    {
        GameCamera.TargetObject(GameObjectRepository.Player);
    }

    public void Draw()
    {
        GameCamera.SetCamera();
        foreach (var entities in GameObjectRepository.Entities)
        {
            entities.Draw();
        }
        GameObjectRepository.Player.Draw();
        Raylib.EndMode2D();
        GameObjectRepository.Player.DrawInfo();

        foreach (var gameEvents in GameEvents)
        {
            gameEvents.Draw();
        }
    }
    public void Update(GameStateManager gameStateManager)
    {
        if (!GameObjectRepository.Player.IsAlive)
        {
            MenuFactory factory = new GameOverMenuCreator();
            gameStateManager.State = factory.Create();
        }
        if (Raylib.IsKeyPressed(KeyboardKey.Escape))
        {
            MenuFactory factory = new GameMenuCreator();
            gameStateManager.State = factory.Create();
        }

        foreach (var events in GameEvents)
        {
            events.StartEvent();
        }

        _collisionDetectionService.CollisionDetection();
        _movementService.MoveObjects();

        StickCameraToplayer();
        GameObjectRepository.RemoveDeadEntities();
    }

}