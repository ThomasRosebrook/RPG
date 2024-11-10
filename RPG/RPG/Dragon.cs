﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;

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
            animationTimer += gameTime.ElapsedGameTime.TotalSeconds;
            if (animationTimer >= frameTime)
            {
                currentFrame = (currentFrame + 1) % frames.Length;
                animationTimer = 0;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spriteSheet, new Vector2(100, 100), frames[currentFrame], Color.White);
        }

        public override void LoadContent(ContentManager content)
        {
            attackSound = content.Load<SoundEffect>("LightningAttackSFX/EM_1");
            magicSound = content.Load<SoundEffect>("FireAttackSFX/EM_FIRE_LAUNCH_01");
            spriteSheet = content.Load<Texture2D>("Dragon");
            frames = new Rectangle[]
            {
                new Rectangle(0, 0, 60, 60),
                new Rectangle(60, 0, 60, 60)
            };
        }
    }
}
