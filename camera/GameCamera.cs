
using System.Numerics;
using GameObjects;
using Raylib_cs;

namespace Camera; 

public class GameCamera:IGameCamera{
    private Camera2D Camera2D;
    public float Zoom { get; set; }=1.0f;
    public float Rotation {get;set;}=0.0f;
    public GameCamera()
    {
        Camera2D = new Camera2D();
    }

    public void CreateCamera(BaseGameEntity gameObject,int screenWidth, int screenHeight){
            Camera2D.Target = new Vector2(gameObject.X + gameObject.MovementSpeed, gameObject.Y + gameObject.MovementSpeed);
            Camera2D.Offset = new Vector2((screenWidth-122) / 2, (screenHeight-182) / 2);
            Camera2D.Rotation =Rotation;
            Camera2D.Zoom =Zoom;
            //Raylib.SetMouseOffset((int)Camera2D.Offset.X,(int)Camera2D.Offset.Y);
    }

    public void TargetObject(BaseGameEntity gameObject){
          Camera2D.Target = new Vector2(gameObject.X, gameObject.Y );
    }

    public void SetCamera(){
            Raylib.BeginMode2D(Camera2D);
    }

    public Camera2D GetCamera2D()
    {
       return Camera2D;
    }
}