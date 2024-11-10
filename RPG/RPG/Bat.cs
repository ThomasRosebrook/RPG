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
    public class Bat : Enemy
    {

        private Texture2D _spriteSheet;
        private Rectangle[] _frames;
        private int _currentFrame;
        private double _animationTimer;
        private double _frameTime = 0.2;

        

        public Bat()
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

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (InBattle) spriteBatch.Draw(_spriteSheet, BattlePosition, _frames[_currentFrame], Color.White);
            else spriteBatch.Draw(_spriteSheet, (WorldPosition - new Vector2(1, 1)) * 60, _frames[_currentFrame], Color.White);
        }

        public override void LoadContent(ContentManager content)
        {
            _spriteSheet = content.Load<Texture2D>("Bat");
            _frames = new Rectangle[]
            {
                new Rectangle(0, 0, 60, 60),
                new Rectangle(60, 0, 60, 60)
            };
        }

        
    }
}
