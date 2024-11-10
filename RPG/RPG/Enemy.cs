using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public abstract class Enemy
    {
        public SoundEffect attackSound { get; set; }
        public SoundEffect magicSound { get; set; }
        protected Texture2D spriteSheet { get; set; }
        protected Rectangle[] frames { get; set; }

        protected int currentFrame { get; set; }

        protected const double frameTime = 0.2;

        protected double animationTimer { get; set; }

        protected int HP { get; set; }

        protected int Strength { get; set; }

        protected int Magic { get; set; }

        protected decimal Money { get; set; }

        protected int Luck { get; set; }


        public int GetHP()
        {
            return HP;
        }

        public void SetHP(int hp)
        {
            HP = hp;
        }

        public int GetStrength()
        {
            return Strength;
        }

        public int GetMagic()
        {
            return Magic;
        }

        public decimal GetMoney()
        {
            return Money;
        }

        public int GetLuck()
        {
            return Luck;
        }
        public abstract void Update(GameTime gameTime);
        public abstract void LoadContent(ContentManager content);

        public abstract void Draw(SpriteBatch spriteBatch);
        
    }
}
