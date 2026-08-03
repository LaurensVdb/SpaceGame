using Behavior.Movement;
using Behavior.Shooting;
using ContentManagement;
using Drawing;
using GameObjects.Objects;
using Raylib_cs;
namespace Builders
{
    public class PlayerBuilder : IPlayerBuilder
    {
        private Player _player;

        public PlayerBuilder()
        {
            Reset();
        }

        public void Reset()
        {
            _player = new Player(new PlayerMovement(), new PlayerDrawing(), new PlayerShooting(500), 0, 0, default);
        }


        public void SetHitPoints(int hitPoints)
        {
            _player.HitPoints = hitPoints;
        }

        public void SetPosition(float x, float y)
        {
            _player.X = x;
            _player.Y = y;
        }

        public void SetMovementSpeed(float speed)
        {
            _player.MovementSpeed = speed;
        }

        public void SetProtectionLevel(int protectionLevel)
        {
            _player.ProtectectionLevel = protectionLevel;
        }
        public Player Get()
        {
            return _player;
        }


        public void CreateFromConfig(PlayerConfig config)
        {
            this.SetPosition(config.Position.X, config.Position.Y);
            this.SetTexture(Contentmanager.Instance.TexturesForTypes[new Tuple<Type, int>(typeof(Player), 1)]);
            this.SetMovementSpeed(config.MovementSpeed);
            this.SetHitPoints(config.HitPoints);
            this.SetProtectionLevel(config.ProtectionLevel);

        }

        public void SetTexture(Texture2D texture2D)
        {
            _player.Texture = texture2D;
            _player.Widht = texture2D.Width;
            _player.Height = texture2D.Height;
        }
    }
}