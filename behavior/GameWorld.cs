using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using Camera;
using GameObjects;
using Raylib_cs;

namespace Bevahior;

public sealed class GameWorld{
    public IGameObjectRepository GameObjectRepository{ get; set; }
    public IGameCamera GameCamera{ get; set; }
    public IEnemySpawner EnemySpawner{ get; set; }

    public IParticleSpawner ParticleSpawner { get; set; }

    private int screenWidth;
    private int screenHeight;
    private int wave=1;
    public GameWorld(IGameObjectRepository gameObjectRepository,IGameCamera camera,IEnemySpawner enemySpawner,IParticleSpawner particleSpawner,int screenwidth, int screenheight)
    {
        this.GameObjectRepository = gameObjectRepository; 
        this.EnemySpawner = enemySpawner; 
        this.GameCamera = camera;
        this.screenHeight = screenheight; 
        this.screenWidth = screenwidth;
        this.ParticleSpawner = particleSpawner;
        CreateCameraForPlayer();
       
    }
    
    private void CreateCameraForPlayer(){
        GameCamera.CreateCamera(GameObjectRepository.Player,screenWidth , screenHeight);
    }
    private void StickCameraToplayer(){
        GameCamera.TargetObject(GameObjectRepository.Player);
    }

    private void SpawnEnemies(){
        EnemySpawner.StartEnemySpawner(screenWidth,screenHeight,GameObjectRepository,wave);
    }
      private void SpawnParticles(){
        ParticleSpawner.StartParticleSpawner(screenWidth,screenHeight,GameObjectRepository);
    }
    public void CreatePlayer(BaseGameEntity player){
        GameObjectRepository.SetPlayer(player);
        CreateCameraForPlayer();
    }

    public void DrawWorld(){
        GameCamera.SetCamera();
        foreach(var entities in GameObjectRepository.Entities){
            entities.Draw();
        }
        GameObjectRepository.Player.Draw();
        Raylib.EndMode2D(); 
        GameObjectRepository.Player.DrawInfo();
         Raylib.DrawText($"Wave {wave}",20, 80, 20, Color.Gold);
        /*foreach(var entities in GameObjectRepository.Entities){
            if(entities is Star)entities.Draw();
        }*/
    }
    public void UpdateWorld(){
        SpawnEnemies();
        SpawnParticles();
        CollisionCheck();
        CheckWave();

        var gameEntities = GameObjectRepository.Entities.ToList();
        foreach(var entity in gameEntities){
          
            if(entity is Enemy) {
                entity.Move((int)GameObjectRepository.Player.X,(int)GameObjectRepository.Player.Y);
                if(entity.CanShoot){
                    entity.Shoot(GameObjectRepository);
                }

            }else{
                entity.Move();
            }
            
        }
        
        //var newpos = Raylib.GetWorldToScreen2D(new Vector2(GameObjectRepository.Player.X,GameObjectRepository.Player.Y),GameCamera.GetCamera2D()));
        GameObjectRepository.Player.Move((int)GameCamera.GetCamera2D().Offset.X,(int)GameCamera.GetCamera2D().Offset.Y);
        GameObjectRepository.Player.Shoot(GameObjectRepository);
        StickCameraToplayer();
    }


    private void CheckWave(){
        if(GameObjectRepository.Player.KillCount>=(10*wave)){
            wave+=1;
        }
    }
    private void CollisionCheck(){

        
        var bullets = GameObjectRepository.Entities.Where(p=>p is Bullet) .ToList();
        var enemies = GameObjectRepository.Entities.Where(p=>p is Enemy).ToList();
         foreach(Bullet bullet in bullets ){
             foreach(Enemy enemy in enemies){
                if(!bullet.IsEnemy){
                    var iscollsion = bullet.IsCollision(enemy);
                    if(iscollsion) {
                        GameObjectRepository.Entities.Remove(bullet);
                        if(!enemy.IsAlive){
                            GameObjectRepository.Entities.Remove(enemy);
                            GameObjectRepository.Player.KillCount+=1;

                        }
                    }
                }else{
                     var iscollsion = bullet.IsCollision( GameObjectRepository.Player);
                      if(iscollsion) {
                        GameObjectRepository.Entities.Remove(bullet);
                        if(!enemy.IsAlive){
                            GameObjectRepository.Entities.Remove(enemy);
                        

                        }
                    }
                }
            }
         }
      


        foreach(var entity in enemies){
            var checkObjects = enemies.Where(p=>p is Enemy).ToList();
          
            checkObjects.Remove(entity);
            foreach(var checkEntity in checkObjects){
                  var result = entity.IsCollision(checkEntity);
            }
         
        }
    }

}