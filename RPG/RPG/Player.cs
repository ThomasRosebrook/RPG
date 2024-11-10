using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
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

        private Texture2D battleTexture;

        private Texture2D worldTexture;

        private int animationIndex = 0;

        private double animationTimer = 0;

        public Vector2 Position { get; set; }

        public TurnAction Action;

        public int PositionX;
        public int PositionY;

        public void LoadContent()
        {
            battleTexture = _content.Load<Texture2D>("MainCharacterFight");
            worldTexture = _content.Load<Texture2D>("Player");
        }

        public void Update(GameTime gameTime)
        {
            if (animationTimer >= 5)
            {
                animationTimer -= 5;
                animationIndex = (animationIndex == 1) ? 0 : 1;
            }
            else animationTimer += gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(worldTexture, Position, new Rectangle(animationIndex * 60, 0,60,60), Color.White);
        }

    }
}
