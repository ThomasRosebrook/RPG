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

        public MainMenu()
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

            if (input.Escape) ScreenManager.Game.Exit();

            if (input.Space)
            {
                ScreenManager.AddScreen(new DialogueBox("This is the name", "This is the text to display."));
                //this.ExitScreen();
            }

        }

        public override void Draw(GameTime gameTime)
        {
            ScreenManager.GraphicsDevice.Clear(ClearOptions.Target, Color.Gray, 0, 0);

            var spriteBatch = ScreenManager.SpriteBatch;

            spriteBatch.Begin();

            string currentText = "The Quest For RPG";
            Vector2 size = PixelFont.SizeOf(currentText, FontSize.Large);
            PixelFont.DrawString(spriteBatch, FontSize.Large, new Vector2(width / 2 - size.X / 2, 20), Color.White, currentText);

            currentText = "Exit: ESC or Back";
            size = PixelFont.SizeOf(currentText, FontSize.Medium);
            PixelFont.DrawString(spriteBatch, FontSize.Medium, new Vector2(width / 2 - size.X / 2, height - size.Y), Color.White, currentText);

            spriteBatch.End();
        }
    }
}
