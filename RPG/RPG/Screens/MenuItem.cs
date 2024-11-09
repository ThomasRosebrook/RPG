using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace RPG.Screens
{
    public class MenuItem
    {
        public string Name { get; set; }

        public bool IsHovered { get; set; }

        public FontSize FontSize { get; set; } = FontSize.Small;

        public MenuItem(string itemName) 
        {
            Name = itemName;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 menuPosition)
        {
            Color color = (IsHovered) ? Color.White : Color.Black;
            PixelFont.DrawString(spriteBatch, FontSize, menuPosition, color, Name);
        }
    }
}
