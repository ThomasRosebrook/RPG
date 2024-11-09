using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RPG
{
    public static class PixelFont
    {
        static SpriteFont SmallFont;
        static SpriteFont MediumFont;
        static SpriteFont LargeFont;

        static bool isInitialized;

        public static void LoadFonts(ContentManager content)
        {
            if (!isInitialized)
            {
                SmallFont = content.Load<SpriteFont>("PublicPixelSmall");
                MediumFont = content.Load<SpriteFont>("PublicPixel");
                LargeFont = content.Load<SpriteFont>("PublicPixelLarge");
            }
        }

        public static Vector2 SizeOf(string text, FontSize size)
        {
            return GetFontFromSize(size).MeasureString(text);
        }

        public static void DrawString (SpriteBatch spriteBatch, FontSize size, Vector2 position, Color color, string text)
        {
            spriteBatch.DrawString(GetFontFromSize(size), text, position, color);
        }

        public static SpriteFont GetFontFromSize(FontSize size)
        {
            switch (size)
            {
                case FontSize.Small:
                    return SmallFont;
                case FontSize.Medium:
                    return MediumFont;
                case FontSize.Large:
                    return LargeFont;
                default:
                    return MediumFont;
            }
        }

        public static int CharsPerLine(int length, FontSize size)
        {
            switch (size)
            {
                case FontSize.Small:
                    return length / 12;
                case FontSize.Medium:
                    return length / 24;
                case FontSize.Large:
                    return length / 36;
                default:
                    return length / 24;
            }
        }
    }

    public enum FontSize
    {
        Small,
        Medium,
        Large
    }
}
