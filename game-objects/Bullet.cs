using System;
using System.Numerics;
using System.Text.RegularExpressions;
using GameObjects;
using Raylib_cs;

namespace GameObjects;

public class Bullet : BaseGameEntity
{
    private float bulletRotation;
    private bool isEnemy;
    public  bool IsEnemy { get{ return isEnemy;}}
    public Bullet(float x, float y,int widht,int height,float movementSpeed,int hitPoints,float bulletRotation,bool isEnemy=false) : base(x,y,widht,height,movementSpeed,hitPoints)
    {
        this.bulletRotation = bulletRotation;
        this.isEnemy=isEnemy;
    }

    public override bool IsCollision(BaseGameEntity entityCollisionCheck)
    {
        var isCollision =  base.IsCollision(entityCollisionCheck);
        if(entityCollisionCheck is Enemy){
            if(isCollision && IsAlive){
                IsAlive=false;
                entityCollisionCheck.TakeDamage(1);
            }
          
        }
        if(entityCollisionCheck is Player){
            if(isCollision && IsAlive){
                IsAlive=false;
                entityCollisionCheck.TakeDamage(1);
            }
          
        }
       return isCollision;
    }
    public override void Move()
    {
        X += MathF.Cos((bulletRotation-90) * (MathF.PI / 180)) * MovementSpeed;
        Y += MathF.Sin((bulletRotation-90)* (MathF.PI / 180)) * MovementSpeed;
    }
    public override void Draw()
    {
          //Raylib.DrawCircleV(new Vector2(X,Y), 5, Color.White);
          if(IsAlive){
             Raylib.DrawRectangle((int)CollisionRectangle.X,(int)CollisionRectangle.Y,(int)CollisionRectangle.Width*2,(int)CollisionRectangle.Height*2,Color.Gold);
          }
         
    }
}