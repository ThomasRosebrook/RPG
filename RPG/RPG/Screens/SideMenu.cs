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
    public class SideMenu : GameScreen
    {
        private ContentManager _content;

        private int width;
        private int height;

        Texture2D background;

        List<MenuItem> items;

        int selectedItem = 0;

        public SideMenu()
        {
            this.IsPopup = true;
            items = new List<MenuItem>()
            {
                new MenuItem("Save"),
                new MenuItem("Stats"),
                new MenuItem("Exit Game"),
                new MenuItem("Back")
            };
            items[0].IsHovered = true;
        }

        public override void Activate()
        {
            if (_content == null) _content = new ContentManager(ScreenManager.Game.Services, "Content");

            if (width <= 0) width = ScreenManager.GraphicsDevice.Viewport.Width;
            if (height <= 0) height = ScreenManager.GraphicsDevice.Viewport.Height;

            background = _content.Load<Texture2D>("SideMenuBG");
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

            if (!input.DirectionChanged)
            {
                if (input.Escape) this.ExitScreen();
                if (input.Enter) this.SelectItem();
            }
            else if (input.Direction.Y < 0 && selectedItem > 0)
            {
                items[selectedItem].IsHovered = false;
                selectedItem--;
                items[selectedItem].IsHovered = true;
            }
            else if (input.Direction.Y > 0 && selectedItem < items.Count - 1)
            {
                items[selectedItem].IsHovered = false;
                selectedItem++;
                items[selectedItem].IsHovered = true;
            }

        }

        public override void Draw(GameTime gameTime)
        {
            ScreenManager.GraphicsDevice.Clear(ClearOptions.Target, Color.Gray, 0, 0);

            var spriteBatch = ScreenManager.SpriteBatch;

            spriteBatch.Begin();

            spriteBatch.Draw(background, new Vector2(600,0), Color.White);

            for (int i = 0; i < items.Count; i++)
            {
                items[i].Draw(spriteBatch, new Vector2(650, 50 + i * 75));
            }

            spriteBatch.End();
        }

        private void SelectItem()
        {
            switch (selectedItem)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    ScreenManager.Game.Exit();
                    break;
                case 3:
                    this.ExitScreen();
                    break;
                default:
                    break;
            }
        }
    }
}
