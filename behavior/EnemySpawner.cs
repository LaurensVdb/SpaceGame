using System.Diagnostics;
using Contentmanagement;
using GameObjects;
using Raylib_cs;

namespace Bevahior;

public class EnemySpawner:IEnemySpawner{

    private int maxElapsedMilliseconds=2000;
    private Stopwatch timer;
    public EnemySpawner()
    {
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

                Texture2D texture=new Texture2D();
                float enemyspeed=0f;
                int enemyhitpoints=1;
                var randomNumber = rnd.Next(1,wave+1);
                bool canShoot = false;
                switch(randomNumber)
                {
                    case 1:
                        texture = Contentmanager.Instance.TexturesForTypes[new Tuple<Type, int>(typeof(Enemy),1)];
                        enemyspeed=2f; 
                        enemyhitpoints=1;  
                    break;
                    case 2:
                        texture = Contentmanager.Instance.TexturesForTypes[new Tuple<Type, int>(typeof(Enemy),2)];
                        enemyspeed=2.5f;
                        enemyhitpoints=2;
                        canShoot=true;
                    break;
                    case 3:
                        texture = Contentmanager.Instance.TexturesForTypes[new Tuple<Type, int>(typeof(Enemy),3)];
                        enemyspeed=2.5f;
                        enemyhitpoints=2;
                    break;
                }    
                gameObjectRepository.Entities.Add( new Enemy(newx,newy,enemyspeed,enemyhitpoints,texture,canShoot));
                timer.Start(); 
        }
    }
}