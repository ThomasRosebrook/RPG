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
    public class BottomMenu : GameScreen
    {
        protected ContentManager _content;

        private int width;
        private int height;

        Texture2D background;

        List<MenuItem> items;

        int selectedItem = 0;

        public BottomMenu(string option1, string option2, string option3, string option4)
        {
            this.IsPopup = true;
            items = new List<MenuItem>()
            {
                new MenuItem(option1) { FontSize = FontSize.Medium },
                new MenuItem(option2) { FontSize = FontSize.Medium },
                new MenuItem(option3) { FontSize = FontSize.Medium },
                new MenuItem(option4) { FontSize = FontSize.Medium }
            };
            items[0].IsHovered = true;
        }

        public override void Activate()
        {
            if (_content == null) _content = new ContentManager(ScreenManager.Game.Services, "Content");

            if (width <= 0) width = ScreenManager.GraphicsDevice.Viewport.Width;
            if (height <= 0) height = ScreenManager.GraphicsDevice.Viewport.Height;

            background = _content.Load<Texture2D>("BottomMenuBG");
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
                //if (input.Escape) this.ExitScreen();
                if (input.Enter) this.SelectItem();
            }
            else
            {
                if (input.Direction.Y < 0 && selectedItem >= 2)
                {
                    items[selectedItem].IsHovered = false;
                    selectedItem -= 2;
                    items[selectedItem].IsHovered = true;
                }
                else if (input.Direction.Y > 0 && selectedItem < 2)
                {
                    items[selectedItem].IsHovered = false;
                    selectedItem += 2;
                    items[selectedItem].IsHovered = true;
                }

                if (input.Direction.X < 0 && (selectedItem == 1 || selectedItem == 3))
                {
                    items[selectedItem].IsHovered = false;
                    selectedItem -= 1;
                    items[selectedItem].IsHovered = true;
                }
                else if (input.Direction.X > 0 && (selectedItem == 0 || selectedItem == 2))
                {
                    items[selectedItem].IsHovered = false;
                    selectedItem += 1;
                    items[selectedItem].IsHovered = true;
                }
            }


        }

        public override void Draw(GameTime gameTime)
        {
            var spriteBatch = ScreenManager.SpriteBatch;

            spriteBatch.Begin();

            spriteBatch.Draw(background, new Vector2(0, 700), Color.White);

            items[0].Draw(spriteBatch, new Vector2(100, 730));
            items[1].Draw(spriteBatch, new Vector2(650, 730));
            items[2].Draw(spriteBatch, new Vector2(100, 800));
            items[3].Draw(spriteBatch, new Vector2(650, 800));
            //items[3].Draw(spriteBatch, new Vector2(100, 78));

            spriteBatch.End();
        }

        private void SelectItem()
        {
            switch (selectedItem)
            {
                case 0:
                    SelectOptionOne();
                    break;
                case 1:
                    SelectOptionTwo();
                    break;
                case 2:
                    SelectOptionThree();
                    break;
                case 3:
                    SelectOptionFour();
                    break;
                default:
                    break;
            }
        }

        protected virtual void SelectOptionOne()
        {

        }

        protected virtual void SelectOptionTwo()
        {

        }

        protected virtual void SelectOptionThree()
        {

        }

        protected virtual void SelectOptionFour()
        {

        }
    }
}
