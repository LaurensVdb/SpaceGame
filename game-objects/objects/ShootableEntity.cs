using System;
using System.Numerics;
using Asteroid_game.behavior.shooting;
using Asteroid_game.drawing;
using GameObjects.objects;
using MovmementService;
using Raylib_cs;

namespace Asteroid_game.game_objects.objects;

public abstract  class ShootableEntity : BaseGameEntity
{
    public IShooting ShootingService;
    public ShootableEntity(IMovement movementService, IDrawing drawing, IShooting shootingService, float x, float y, float movementSpeed, int hitPoints, Texture2D texture2D) 
    : base(movementService, drawing, x, y, movementSpeed, hitPoints, texture2D)
    {
        ShootingService = shootingService;
    }

    public abstract Bullet? Shoot();
}
