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
        private Texture2D _texture;

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
