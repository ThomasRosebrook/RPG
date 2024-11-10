using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace RPG
{
    public class Player
    {
        public int HP;

        public int strength;

        public int magic;

        public decimal money;

        public int luck;

        private Texture2D battleTexture;

        private Texture2D worldTexture;

        private int animationIndex = 0;

        private double animationTimer = 0;

        private double movementTimer = 0;

        public bool CanMove = true;

        int width = 60;
        int height = 60;

        public Vector2 Position { get; set; }

        public TurnAction Action;

        public void LoadContent(ContentManager _content)
        {
            battleTexture = _content.Load<Texture2D>("MainCharacterFight");
            worldTexture = _content.Load<Texture2D>("Player");
        }

        public void Update(GameTime gameTime)
        {
            if (animationTimer >= 1)
            {
                animationTimer -= 1;
                animationIndex = (animationIndex == 1) ? 0 : 1;
            }
            else animationTimer += gameTime.ElapsedGameTime.TotalSeconds;

            if (movementTimer >= 150)
            {
                movementTimer -= 150;
                CanMove = true;
            }
            else if (CanMove == false) movementTimer += gameTime.ElapsedGameTime.TotalMilliseconds;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(worldTexture, Position, new Rectangle(animationIndex * 60, 0,60,60), Color.White, 0f, new Vector2(0,0), 1f, SpriteEffects.None, 1);
        }

        public void Move (Vector2 direction)
        {
            Position += direction * 60;
            CanMove = false;
            movementTimer = 0;
        }

    }
}
