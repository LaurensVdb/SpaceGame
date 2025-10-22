using Asteroid_game.behavior.collision;
using Bevahior;
using Camera;
using GameMenuBevahior;
using GameObjects.factories;
using GameObjects.objects;
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

    private ICollisionDetectionService collisionDetectionService;

    public GameWorld(IGameObjectRepository gameObjectRepository, IGameCamera camera, ICollisionDetectionService collisionDetectionService, List<IGameEvent> gameEvents)
    {
        this.GameObjectRepository = gameObjectRepository;
        this.GameCamera = camera;
        this.GameEvents = gameEvents;
        playerFactory = new PlayerFactory();
        this.collisionDetectionService = collisionDetectionService;
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

        collisionDetectionService.CollisionDetection();


        var gameEntities = GameObjectRepository.Entities.ToList();
        foreach (var entity in gameEntities)
        {

            if (entity is Enemy)
            {
                entity.Move((int)GameObjectRepository.Player.CollisionRectangle.X, (int)GameObjectRepository.Player.CollisionRectangle.Y);
                if (entity.CanShoot)
                {
                    entity.Shoot(GameObjectRepository);
                }

            }
            else
            {
                entity.Move();
            }

        }

        //var newpos = Raylib.GetWorldToScreen2D(new Vector2(GameObjectRepository.Player.X,GameObjectRepository.Player.Y),GameCamera.GetCamera2D()));
        GameObjectRepository.Player.Move((int)GameCamera.GetCamera2D().Offset.X, (int)GameCamera.GetCamera2D().Offset.Y);
        GameObjectRepository.Player.Shoot(GameObjectRepository);
        StickCameraToplayer();

        GameObjectRepository.RemoveDeadEntities();
    }

}