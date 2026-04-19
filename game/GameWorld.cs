using Behavior.Movement;
using Behavior.Shooting;
using Camera;
using Behavior.Events;
using Behavior.Collision;
using Menu;
using GameObjects.Repositories;
using GameState;
using Raylib_cs;
namespace Game;

public sealed class GameWorld : IGameState, IGameWorld
{
    public IGameObjectRepository GameObjectRepository { get; set; }


    private readonly List<IGameEvent> _gameEvents;

    private readonly ICollisionDetectionService _collisionDetectionService;
    private readonly IMovementService _movementService;
    private readonly IGameCamera _gameCamera;

    private readonly IShootingService _shootingService;
    private readonly EventRendererRegistry _eventRendererRegistry = new EventRendererRegistry();

    public GameWorld(IGameObjectRepository gameObjectRepository, IGameCamera camera, ICollisionDetectionService collisionDetectionService, IMovementService movementService, IShootingService shootingService, List<IGameEvent> gameEvents)
    {
        this.GameObjectRepository = gameObjectRepository;

        _gameEvents = gameEvents;

        _collisionDetectionService = collisionDetectionService;
        _movementService = movementService;
        _shootingService = shootingService;
        _gameCamera = camera;

        // register default renderers
        _eventRendererRegistry.Register(new WaveEventRenderer());

        GameObjectRepository.CreatePlayer();
        _gameCamera.CreateCamera(GameObjectRepository.Player);
    }


    public void Draw()
    {
        _gameCamera.SetCamera();
        foreach (var entities in GameObjectRepository.Entities)
        {
            entities.Draw((ICameraController)_gameCamera);
        }
        GameObjectRepository.Player.Draw((ICameraController)_gameCamera);


        foreach (var gameEvent in _gameEvents)
        {
            _eventRendererRegistry.Render(gameEvent, (ICameraController)_gameCamera);
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

        foreach (var events in _gameEvents)
        {
            events.StartEvent();
        }

        _collisionDetectionService.CollisionDetection();
        _movementService.MoveObjects();
        _shootingService.Shoot();
        _gameCamera.TargetObject(GameObjectRepository.Player);
        GameObjectRepository.RemoveDeadEntities();
    }

}