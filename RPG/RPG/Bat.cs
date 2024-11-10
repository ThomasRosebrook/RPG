﻿using System;
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
        private ContentManager _content;

        private Texture2D _texture;
        
        public Bat()
        {
            HP = 20;
            Strength = 10;
            Magic = 10;
            Money = 2.00M;
            Luck = 2;
        }

        public void Update(GameTime gameTime)
        {

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, new Rectangle(600, 350, 200, 200), Color.White);
        }

        public override void LoadContent(ContentManager content)
        {
            _texture = content.Load<Texture2D>("BatMonster");
        }

        
    }
}
