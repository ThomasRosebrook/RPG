using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RPG
{
    public class Guard : Enemy
    {
        public Guard()
        {
            HP = 20;
            Strength = 10;
            Magic = 10;
            Money = 2.00M;
            Luck = 2;
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
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
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
