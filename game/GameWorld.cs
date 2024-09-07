using Bevahior;
using Camera;
using GameObjects.repositories;
using GameStateBevahior;
using Raylib_cs;
using GameObjects.objects;
using GameObjects.factories;
using GameMenuBevahior;
namespace Game;

public sealed class GameWorld :IGameState, IGameWorld
{
    public IGameObjectRepository GameObjectRepository { get; set; }
    public IGameCamera GameCamera { get; set; }
    public IEnemySpawner EnemySpawner { get; set; }

    public IParticleSpawner ParticleSpawner { get; set; }
    private PlayerFactory playerFactory;

    public int ScreenWidth {get{return Raylib.GetScreenWidth();}}
    public int ScreenHeight {get{return Raylib.GetScreenHeight();}}
    public int Wave {get;set;}
    public GameWorld(IGameObjectRepository gameObjectRepository,IGameCamera camera, IEnemySpawner enemySpawner, IParticleSpawner particleSpawner)
    {
        this.GameObjectRepository = gameObjectRepository;
        this.EnemySpawner = enemySpawner;
        this.GameCamera = camera;
       
        this.ParticleSpawner = particleSpawner;
 
       
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

    private void SpawnEnemies()
    {
        EnemySpawner.StartEnemySpawner(ScreenWidth, ScreenHeight, GameObjectRepository, Wave);
    }
    private void SpawnParticles()
    {
        ParticleSpawner.StartParticleSpawner(ScreenWidth, ScreenHeight, GameObjectRepository);
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
        Raylib.DrawText($"Wave {Wave}", 20, 80, 20, Color.Gold);
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
        SpawnEnemies();
        SpawnParticles();
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
        if (GameObjectRepository.Player.KillCount >= (10 * Wave))
        {
            Wave += 1;
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