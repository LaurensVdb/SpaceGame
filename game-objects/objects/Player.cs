
using System.Numerics;
using Raylib_cs;
using GameObjects.repositories;

namespace GameObjects.objects;
public class Player :BaseGameEntity{


  


    public Player(float x, float y,float movementSpeed,int hitPoints,Texture2D texture2D) : base(x,y,movementSpeed,hitPoints,texture2D)
    {
     
    }

    public override void Move(int targetX,int targetY){

        var mousePosition = Raylib.GetMousePosition();
        float deltaX = mousePosition.X -targetX;
        float deltaY = mousePosition.Y- targetY; 
        Rotation = MathF.Atan2(deltaY, deltaX) * (180f / MathF.PI)+90;
        
        if (Raylib.IsKeyDown(KeyboardKey.Right)) {
            if (Raylib.IsKeyDown(KeyboardKey.Right)) X += MovementSpeed;
        }
        if (Raylib.IsKeyDown(KeyboardKey.Left)) X -= MovementSpeed;
        if (Raylib.IsKeyDown(KeyboardKey.Up)) Y -= MovementSpeed;
        if (Raylib.IsKeyDown(KeyboardKey.Down)) Y += MovementSpeed;

        if (Raylib.IsMouseButtonPressed(MouseButton.Left)){
            //schiet
            IsShooting=true;
           
        }else{
            IsShooting=false;
        };
    
    }

    public override void Shoot(IGameObjectRepository gameObjectRepository){
        if(IsShooting){
            var rotatepoint = RotatePoint(new Vector2(X +Widht/2 ,Y +Height/2 ),new Vector2(X,Y),Rotation);
            gameObjectRepository.AddEntity(new Bullet(rotatepoint.X,rotatepoint.Y,5,5,10f,0,Rotation));
        }
     
    }

    private Vector2 RotatePoint(Vector2 pointToRotate, Vector2 centerPoint, float angleInDegrees)
    {
        float angleInRadians = angleInDegrees * (MathF.PI / 180);
        float cosTheta = MathF.Cos(angleInRadians);
        float sinTheta = MathF.Sin(angleInRadians);
        return new Vector2
        {
            X = cosTheta * (pointToRotate.X - centerPoint.X) - sinTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.X,
            Y = sinTheta * (pointToRotate.X - centerPoint.X) + cosTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.Y
        };
    }

    public override void Draw(){
        
        Raylib.DrawTextureEx(Texture,new Vector2(X,Y),Rotation,1f,Color.White);

        //var pos =RotatePoint(new Vector2(X +Widht/2 ,Y +Height/2 ),new Vector2(X,Y),Rotation);
        /* var pos = new Vector2
        {
            X = (X+25 - X) * cosTheta -  (Y+25 - Y) * sinTheta +(X - 25),
            Y = (Y+25 - Y) * sinTheta +(X+25 - X) * cosTheta +(Y -25)
        }; */

        //Raylib.DrawText(X.ToString(),200,200,5,Color.Red);
        //Raylib.DrawText(Y.ToString(),200,250,5,Color.Red);
        //Raylib.DrawText(angleInRadians.ToString(),200,350,5,Color.Red);
        //Raylib.DrawRectangle((int)pos.X,(int)pos.Y,(int)50,(int)50,Color.Red);
        //Raylib.DrawRectangle((int)CollisionRectangle.X,(int)CollisionRectangle.Y,(int)CollisionRectangle.Width,(int)CollisionRectangle.Height,Color.Beige);
    }

    public override void DrawInfo(){
        
          Raylib.DrawText("Hitpoints",20, 20, 20, Color.Gold);
          for(var hp=0;hp<HitPoints;hp++){
            Raylib.DrawRectangle(120+(hp*20),20,10,20,Color.Gold);
          }
           Raylib.DrawText($"Kill count {KillCount}",20, 120, 20, Color.Gold);
           Raylib.DrawText(Raylib.GetFPS().ToString(), 500,30,10,Color.Gold);
    }


}