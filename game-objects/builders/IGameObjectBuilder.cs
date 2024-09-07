using Raylib_cs;

public interface IGameObjectBuilder{
    public  void SetTexture(Texture2D texture2D);
    public  void SetPosition(float x, float y);
    void CanShoot(bool canshoot);
    void SetHitpoints(int hitPoints); 

    void IsMovable(bool isMoving);
    void IsAlive(bool isAlive);

    void SetSpeed(float speed);

}