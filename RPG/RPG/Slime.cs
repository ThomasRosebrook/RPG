using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace RPG
{
    public class Slime : Enemy
    {
        private Texture2D _spriteSheet;
        private Rectangle[] _frames;
        private int _currentFrame;
        private double _animationTimer;
        private double _frameTime = 0.2;
        public Slime()
        {
            HP = 50;
            Strength = 5;
            Magic = 20;
            Money = 5.00M;
            Luck = 5;
        }

        public override void Update(GameTime gameTime)
        {
            _animationTimer += gameTime.ElapsedGameTime.TotalSeconds;
            if (_animationTimer >= _frameTime)
            {
                _currentFrame = (_currentFrame + 1) % _frames.Length;
                _animationTimer = 0; 
            }
        }
        public override void LoadContent(ContentManager content)
        {
            _spriteSheet = content.Load<Texture2D>("Slime");
            _frames = new Rectangle[]
            {
                new Rectangle(0, 0, 60, 60),
                new Rectangle(60, 0, 60, 60) 
            };
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_spriteSheet, new Vector2(100, 100), _frames[_currentFrame], Color.White);
        }
    }
}
