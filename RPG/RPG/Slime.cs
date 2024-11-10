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
        private ContentManager _content;
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

        public void Draw(GameTime gameTime)
        {

        }

        public override void LoadContent()
        {
            _content.Load<Texture2D>("BatMonster");
        }
    }
}
