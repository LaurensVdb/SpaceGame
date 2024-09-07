using System.Diagnostics;
using Contentmanagement;
using GameObjects.objects;
using GameObjects.repositories;
using Raylib_cs;

namespace Bevahior;

public class EnemySpawner:IEnemySpawner{

    private EnemyBuilder enemyBuilder;
    private int maxElapsedMilliseconds=2000;
    private Stopwatch timer;
    public EnemySpawner()
    {
        enemyBuilder = new EnemyBuilder();
        timer = new Stopwatch();
    }

    public void StartEnemySpawner(int screenWidth , int screenHeight,IGameObjectRepository gameObjectRepository ,int wave){
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
                var randomNumber = rnd.Next(1,wave+1);
              
                switch(randomNumber)
                {
                    case 1:
                        enemyBuilder.SetTexture(Contentmanager.Instance.TexturesForTypes[new Tuple<Type, int>(typeof(Enemy),1)]);
                        enemyBuilder.SetSpeed(2f);
                        enemyBuilder.SetHitpoints(1);  
                    break;
                    case 2:
                        enemyBuilder.SetTexture(Contentmanager.Instance.TexturesForTypes[new Tuple<Type, int>(typeof(Enemy),2)]);
                        enemyBuilder.SetSpeed(2.5f);
                        enemyBuilder.SetHitpoints(2);  
                        enemyBuilder.CanShoot(true);
                      
                    break;
                    case 3:
                         enemyBuilder.SetTexture(Contentmanager.Instance.TexturesForTypes[new Tuple<Type, int>(typeof(Enemy),3)]);
                        enemyBuilder.SetSpeed(2.5f);
                        enemyBuilder.SetHitpoints(2);  
                      
                    break;
                }    

                //new Enemy(newx,newy,enemyspeed,enemyhitpoints,texture,canShoot)
                gameObjectRepository.Entities.Add(enemyBuilder.GetItem());
                timer.Start(); 
        }
    }
}