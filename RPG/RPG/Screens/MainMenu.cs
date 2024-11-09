using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using RPG.ScreenManagement;

namespace RPG.Screens
{
    public class MainMenu : GameScreen
    {
        private ContentManager _content;

        private int width;
        private int height;

        SpriteFont font;

        public MainMenu()
        {

        }

        public override void Activate()
        {
            if (_content == null) _content = new ContentManager(ScreenManager.Game.Services, "Content");
            if (font == null) font = ScreenManager.Font;

            if (width <= 0) width = ScreenManager.GraphicsDevice.Viewport.Width;
            if (height <= 0) height = ScreenManager.GraphicsDevice.Viewport.Height;
        }

        public override void Unload()
        {
            _content.Unload();
        }

        public override void Update(GameTime gameTime, bool unfocused, bool covered)
        {
            base.Update(gameTime, unfocused, covered);

            if (IsActive)
            {

            }
        }

        public override void HandleInput(GameTime gameTime, InputManager input)
        {
            base.HandleInput(gameTime, input);

            if (input.Escape) ScreenManager.Game.Exit();

        }

        public override void Draw(GameTime gameTime)
        {
            ScreenManager.GraphicsDevice.Clear(ClearOptions.Target, Color.Gray, 0, 0);

            var spriteBatch = ScreenManager.SpriteBatch;

            spriteBatch.Begin();

            string currentText = "The Quest For RPG";
            Vector2 size = font.MeasureString(currentText);
            spriteBatch.DrawString(font, currentText, new Vector2(width / 2 - size.X / 2, 20), Color.White);

            currentText = "Exit: ESC or Back";
            size = font.MeasureString(currentText);
            spriteBatch.DrawString(font, currentText, new Vector2(width / 2 - size.X / 2, height - size.Y), Color.White);

            spriteBatch.End();
        }
    }
}
