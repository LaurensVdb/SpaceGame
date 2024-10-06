using System.Diagnostics;
using bevahior;
using Contentmanagement;
using GameObjects.objects;
using GameObjects.repositories;
using Raylib_cs;

namespace Bevahior;

public class EnemySpawner:GameEvent{

    private EnemyBuilder enemyBuilder;
    private int maxElapsedMilliseconds=500;


    private IGameObjectRepository gameObjectRepository;
    public EnemySpawner(IGameObjectRepository gameObjectRepository)
    {
        enemyBuilder = new EnemyBuilder();
     
        this.gameObjectRepository = gameObjectRepository;
    }

    public override void EndEvent()
    {
        throw new NotImplementedException();
    }

    public override void PauseEvent()
    {
        throw new NotImplementedException();
    }

    public  override void StartEvent(){
        var screenWidth = Raylib.GetScreenWidth(); 
        var screenHeight = Raylib.GetScreenHeight(); 
    
        timer.Start();
        if(timer.ElapsedMilliseconds>=maxElapsedMilliseconds) {
                timer.Reset(); 
                Random rnd = new Random();
             
                var randomdirection = rnd.Next(1,3); 

                float newx=0,newy=0;
                switch(randomdirection){
                    case 1:
                        //boven 
                        newx =rnd.Next((int)gameObjectRepository.Player.X - (screenWidth/2),(int)gameObjectRepository.Player.X + (screenWidth/2)); 
                        newy = gameObjectRepository.Player.Y - (screenHeight/2);
                    break;
                    case 2:
                        //onder 
                        newx =rnd.Next((int)gameObjectRepository.Player.X - (screenWidth/2),(int)gameObjectRepository.Player.X + (screenWidth/2)); 
                        newy = gameObjectRepository.Player.Y + (screenHeight/2);
                    break;
                
                }
           
                enemyBuilder.SetPosition(newx,newy);
                enemyBuilder.IsAlive(true);
                enemyBuilder.IsMovable(true);
                var randomNumber = rnd.Next(1,gameObjectRepository.CurrentWave+1);
              
                switch(randomNumber)
                {
                    
                    case 1:
                        enemyBuilder.SetTexture(Contentmanager.Instance.TexturesForTypes[new Tuple<Type, int>(typeof(Enemy),1)]);
                        enemyBuilder.SetSpeed(2f);
                        enemyBuilder.SetHitpoints(1);  
                         gameObjectRepository.Entities.Add(enemyBuilder.GetItem());
                    break;
                    case 2:
                        enemyBuilder.SetTexture(Contentmanager.Instance.TexturesForTypes[new Tuple<Type, int>(typeof(Enemy),2)]);
                        enemyBuilder.SetSpeed(2.5f);
                        enemyBuilder.SetHitpoints(2);  
                        enemyBuilder.CanShoot(true);
                         gameObjectRepository.Entities.Add(enemyBuilder.GetItem());
                      
                    break;
                    case 3:
                        enemyBuilder.SetTexture(Contentmanager.Instance.TexturesForTypes[new Tuple<Type, int>(typeof(Enemy),3)]);
                        enemyBuilder.SetSpeed(4f);
                        enemyBuilder.SetHitpoints(2); 
                        gameObjectRepository.Entities.Add(enemyBuilder.GetItem());
                    break;
                    case 4:
                        enemyBuilder.SetTexture(Contentmanager.Instance.TexturesForTypes[new Tuple<Type, int>(typeof(Enemy),3)]);
                        enemyBuilder.SetSpeed(4f);
                        enemyBuilder.SetHitpoints(2); 
                        enemyBuilder.CanShoot(true); 
                      
                    break;
                }    

                timer.Start(); 
        }
    }
}