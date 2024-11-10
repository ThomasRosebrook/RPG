using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace RPG
{
    public class HealthBar
    {
        private int MaxHealth;

        public int Health;

        bool IsPlayer = false;

        static Texture2D playerHealth;

        static Texture2D enemyHealth;

        public HealthBar (bool isPlayer, int maxHealth)
        {
            Health = maxHealth;
            MaxHealth = maxHealth;
            IsPlayer = isPlayer;
        }

        public static void InitializeTextures(ContentManager content)
        {
            playerHealth = content.Load<Texture2D>("PlayerHealth");
            enemyHealth = content.Load<Texture2D>("EnemyHealth");
        }

        public void Draw (SpriteBatch spriteBatch) 
        {
            if (!IsPlayer)
            {
                spriteBatch.Draw(enemyHealth, new Vector2(20, 20), new Rectangle(0, GetHealthIndex() * 48, 300, 48), Color.White);
                PixelFont.DrawString(spriteBatch, FontSize.Small, new Vector2(40, 35), Color.White, $"{Health} / {MaxHealth}");
            }
            else
            {
                spriteBatch.Draw(playerHealth, new Vector2(580, 632), new Rectangle(0, GetHealthIndex() * 48, 300, 48), Color.White);
                PixelFont.DrawString(spriteBatch, FontSize.Small, new Vector2(600, 648), Color.White, $"{Health} / {MaxHealth}");
            }

            
        }

        public void UpdateHealth(int health)
        {
            Health = health;
        }

        private int GetHealthIndex()
        {
            int index = 4;

            if (Health <= 0) index = 0;
            else if (Health <= (float)MaxHealth / 4) index = 1;
            else if (Health <= (float)MaxHealth / 2) index = 2;
            else if (Health <= 3 * (float)MaxHealth / 4) index = 3;

            return index;
        }
    }
}
