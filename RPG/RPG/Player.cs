using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;

namespace RPG
{
    public class Player
    {
        private ContentManager _content;

        public int HP;

        public int strength;

        public int magic;

        public decimal money;

        public int luck;

        private Texture2D texture;

        public TurnAction Action;

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("MainCharacterFight");
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Vector2(100, 450), Color.White);
        }
    }
}
