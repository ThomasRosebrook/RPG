using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using RPG.ScreenManagement;

namespace RPG.Screens
{
    public class GameOver : GameScreen
    {
        private ContentManager _content;

        private int width;
        private int height;

        public GameOver()
        {

        }

        public override void Activate()
        {
            if (_content == null) _content = new ContentManager(ScreenManager.Game.Services, "Content");

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

            if (input.Escape)
            {
                ScreenManager.Game.Exit();
            }
            if (input.Space || input.Enter)
            {
                ScreenManager.AddScreen(new MainMenu());
                this.ExitScreen();
            }
        }

        public override void Draw(GameTime gameTime)
        {
            ScreenManager.GraphicsDevice.Clear(ClearOptions.Target, Color.Maroon, 0, 0);

            var spriteBatch = ScreenManager.SpriteBatch;

            spriteBatch.Begin();

            string currentText = "GAME OVER";
            Vector2 size = PixelFont.SizeOf(currentText, FontSize.Large);
            PixelFont.DrawString(spriteBatch, FontSize.Large, new Vector2(width / 2 - size.X / 2, 20), Color.White, currentText);

            currentText = "Continue?";
            size = PixelFont.SizeOf(currentText, FontSize.Medium);
            PixelFont.DrawString(spriteBatch, FontSize.Medium, new Vector2(width / 2 - size.X / 2, height / 2 - size.Y / 2), Color.White, currentText);

            currentText = "Exit: ESC or Back";
            size = PixelFont.SizeOf(currentText, FontSize.Medium);
            PixelFont.DrawString(spriteBatch, FontSize.Medium, new Vector2(width / 2 - size.X / 2, height - size.Y), Color.White, currentText);

            spriteBatch.End();
        }
    }
}
