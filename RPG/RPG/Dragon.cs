using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Dragon : Enemy
    {
        public Dragon()
        {
            HP = 200;
            Strength = 30;
            Magic = 10;
            Money = 10000.00M;
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

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_spriteSheet, new Vector2(100, 100), _frames[_currentFrame], Color.White);
        }

        public override void LoadContent(ContentManager content)
        {
            _spriteSheet = content.Load<Texture2D>("Guard");
            _frames = new Rectangle[]
            {
                new Rectangle(0, 0, 60, 60),
                new Rectangle(60, 0, 60, 60)
            };
        }
    }
}
