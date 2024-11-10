using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RPG
{
    public class Guard : Enemy
    {
        public Guard()
        {
            HP = 50;
            Strength = 15;
            Magic = 5;
            Money = (decimal)RandomHelper.Next(2,20);
            Luck = 2;
        }

        public override void Update(GameTime gameTime)
        {
            animationTimer += gameTime.ElapsedGameTime.TotalSeconds;
            if (animationTimer >= frameTime)
            {
                currentFrame = (currentFrame + 1) % frames.Length;
                animationTimer = 0;
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (InBattle) spriteBatch.Draw(spriteSheet, BattlePosition, frames[currentFrame], Color.White);
            else spriteBatch.Draw(spriteSheet, (WorldPosition - new Vector2(1, 1)) * 60, frames[currentFrame], Color.White);
        }

        public override void LoadContent(ContentManager content)
        {
            attackSound = content.Load<SoundEffect>("Slime1");
            magicSound = content.Load<SoundEffect>("Slime2");
            spriteSheet = content.Load<Texture2D>("Guard");
            frames = new Rectangle[]
            {
                new Rectangle(0, 0, 60, 60),
                new Rectangle(60, 0, 60, 60)
            };
        }

        
    }
}
