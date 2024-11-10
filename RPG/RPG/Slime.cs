using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

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

        public override void Update(GameTime gameTime)
        {
            animationTimer += gameTime.ElapsedGameTime.TotalSeconds;
            if (animationTimer >= frameTime)
            {
                currentFrame = (currentFrame + 1) % frames.Length;
                animationTimer = 0; 
            }
        }
        public override void LoadContent(ContentManager content)
        {
            attackSound = content.Load<SoundEffect>("Slime1");
            magicSound = content.Load<SoundEffect>("Slime2");
            spriteSheet = content.Load<Texture2D>("Slime");
            frames = new Rectangle[]
            {
                new Rectangle(0, 0, 60, 60),
                new Rectangle(60, 0, 60, 60) 
            };
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (InBattle) spriteBatch.Draw(_spriteSheet, BattlePosition, _frames[_currentFrame], Color.White);
            else spriteBatch.Draw(_spriteSheet, (WorldPosition - new Vector2(1,1)) * 60, _frames[_currentFrame], Color.White);
        }
    }
}
