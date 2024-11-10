using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;

namespace RPG
{
    public class Slime : Enemy
    {
        
        public Slime()
        {
            HP = 50;
            Strength = 5;
            Magic = 20;
            Money = 5.00M;
            Luck = 5;
        }

        public void Update(GameTime gameTime)
        {

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

        }

        public override void LoadContent(ContentManager content)
        {
            content.Load<Texture2D>("Slime");
        }
    }
}
