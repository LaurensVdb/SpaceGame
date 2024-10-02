using Bevahior;
using Camera;
using GameObjects.repositories;
using GameStateBevahior;
using Raylib_cs;
using GameObjects.objects;
using GameObjects.factories;
using GameMenuBevahior;
using bevahior;
namespace Game;

public sealed class GameWorld :IGameState, IGameWorld
{
    public IGameObjectRepository GameObjectRepository { get; set; }
    public IGameCamera GameCamera { get; set; }
    private PlayerFactory playerFactory;

    public int ScreenWidth {get{return Raylib.GetScreenWidth();}}
    public int ScreenHeight {get{return Raylib.GetScreenHeight();}}
    public List<IGameEvent> GameEvents { get; set; }

    public GameWorld(IGameObjectRepository gameObjectRepository,IGameCamera camera, List<IGameEvent> gameEvents)
    {
        this.GameObjectRepository = gameObjectRepository;
        this.GameCamera = camera;
        this.GameEvents=gameEvents;       
        playerFactory =new PlayerFactory();
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

    private void CheckIsGameOver(){
        if(!GameObjectRepository.Player.IsAlive){
            //gameState.CurrentGameState = GameStateEnum.GameOver; 
        }
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
        Raylib.DrawText($"Wave {GameObjectRepository.CurrentWave}", 20, 80, 20, Color.Gold);
        /*foreach(var entities in GameObjectRepository.Entities){
            if(entities is Star)entities.Draw();
        }*/
    }
    public void Update(GameStateManager gameStateManager)
    {
       if(!GameObjectRepository.Player.IsAlive){
            MenuFactory factory = new GameOverMenuCreator();
            gameStateManager.State = factory.Create();
        }
        if(Raylib.IsKeyPressed(KeyboardKey.Escape)){
            MenuFactory factory = new GameMenuCreator();
            gameStateManager.State = factory.Create();
        }

        foreach(var events in GameEvents){
            events.StartEvent();
        }

        CollisionCheck();
        CheckWave();

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
    }


    private void CheckWave()
    {
        if (GameObjectRepository.Player.KillCount >= (10 * GameObjectRepository.CurrentWave))
        {
             GameObjectRepository.CurrentWave += 1;
        }
    }
    private void CollisionCheck()
    {

        var bullets = GameObjectRepository.Entities.Where(p => p is Bullet).ToList();
        var enemies = GameObjectRepository.Entities.Where(p => p is Enemy).ToList();

        foreach (Bullet bullet in bullets)
        {
            foreach (Enemy enemy in enemies)
            {
                //check if player bullet hits enemy    
                if (!bullet.IsEnemy)
                {
                    var iscollsion = bullet.IsCollision(enemy);
                    if (iscollsion)
                    {
                        GameObjectRepository.Entities.Remove(bullet);
                        if (!enemy.IsAlive)
                        {
                            GameObjectRepository.Entities.Remove(enemy);
                            //increase killcount. this affects the wave system!
                            GameObjectRepository.Player.KillCount += 1;

                        }
                    }
                }
                else
                {
                    //enemy bullet hits player
                    var iscollsion = bullet.IsCollision(GameObjectRepository.Player);
                    if (iscollsion)
                    {
                        GameObjectRepository.Entities.Remove(bullet);
                        if (!enemy.IsAlive)
                        {
                            GameObjectRepository.Entities.Remove(enemy);
                            if (!enemy.IsAlive)
                            {
                                GameObjectRepository.Entities.Remove(enemy);
                                //increase killcount. this affects the wave system!
                                GameObjectRepository.Player.KillCount += 1;

                            }

                        }
                    }
                }
            }
           

        }

        foreach (var entity in enemies)
        {
            var checkObjects = enemies.Where(p => p is Enemy).ToList();
            //we don't exclude the enemy.
            checkObjects.Remove(entity);

            //check if enemy is hitting an other an enemy
            foreach (var checkEntity in checkObjects)
            {
                entity.IsCollision(checkEntity);
            }

            entity.IsCollision(GameObjectRepository.Player);

        }
    }

}