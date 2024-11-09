using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using RPG.ScreenManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Screens
{
    public class DialogueBox : GameScreen
    {
        public string Name { get; set; } = "";

        public string DialogueText { get; set; } = "";

        Texture2D boxTexture;

        private ContentManager _content;

        private int width;
        private int height;

        public DialogueBox(string name, string text)
        {
            Name = name;
            DialogueText = text;
            this.IsPopup = true;
        }

        public override void Activate()
        {
            if (_content == null) _content = new ContentManager(ScreenManager.Game.Services, "Content");

            if (width <= 0) width = ScreenManager.GraphicsDevice.Viewport.Width;
            if (height <= 0) height = ScreenManager.GraphicsDevice.Viewport.Height;

            boxTexture = _content.Load<Texture2D>("DialogueBox");
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

            if (input.Space) this.ExitScreen();

        }

        public override void Draw(GameTime gameTime)
        {
            //ScreenManager.GraphicsDevice.Clear(ClearOptions.Target, Color.Gray, 0, 0);

            var spriteBatch = ScreenManager.SpriteBatch;

            spriteBatch.Begin();

            spriteBatch.Draw(boxTexture, new Vector2(50, 700), Color.White);

            Vector2 size = PixelFont.SizeOf(Name, FontSize.Medium);
            PixelFont.DrawString(spriteBatch, FontSize.Medium, new Vector2(60, 704 + (40 - size.Y) / 2), Color.Black, Name);


            size = PixelFont.SizeOf(DialogueText, FontSize.Small);

            int numRows = (int)(size.X / 792) + 1;
            int charsPerRow = 48;

            for (int i = 0; i < numRows; i++)
            {
                string text = (i == numRows - 1) ? DialogueText.Substring(i * charsPerRow) : DialogueText.Substring(i * charsPerRow, charsPerRow);

                if (text[0] == ' ') text = text.Substring(1);
                PixelFont.DrawString(spriteBatch, FontSize.Small, new Vector2(58, 752 + i * (10 + size.Y)), Color.Black, text);
            }

            spriteBatch.End();
        }
    }
}
