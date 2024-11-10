﻿using Microsoft.Xna.Framework.Content;
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
    public class WorldScreen : GameScreen
    {
        private ContentManager _content;

        private int width;
        private int height;

        Tilemap tilemap;

        static List<string> tilemaps = new List<string>
        {
            "Tilemap1.txt",
            "Tilemap2.txt",
            "Tilemap3.txt",
            "Tilemap4.txt",
            "Tilemap5.txt",
            "Tilemap6.txt",
            "Tilemap7.txt",
            "Tilemap8.txt",
            "Tilemap9.txt"
        };

        public static int CurrentTileMap = 7;

        public WorldScreen()
        {

        }

        public override void Activate()
        {
            if (_content == null) _content = new ContentManager(ScreenManager.Game.Services, "Content");

            if (width <= 0) width = ScreenManager.GraphicsDevice.Viewport.Width;
            if (height <= 0) height = ScreenManager.GraphicsDevice.Viewport.Height;
            tilemap = new Tilemap(tilemaps[CurrentTileMap]);
            tilemap.LoadContent(_content);
        }

        public void SetTileMap (int map)
        {
            CurrentTileMap = map;
            tilemap = new Tilemap(tilemaps[CurrentTileMap]);
            if (_content == null) tilemap.LoadContent(_content);
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
                ScreenManager.AddScreen(new SideMenu());
                //ScreenManager.Game.Exit();
            }

            if (input.Space)
            {
                ScreenManager.AddScreen(new DialogueBox("Dialogue", "Hello world!"));
                //this.ExitScreen();
            }

        }

        public override void Draw(GameTime gameTime)
        {
            ScreenManager.GraphicsDevice.Clear(ClearOptions.Target, Color.Gray, 0, 0);

            var spriteBatch = ScreenManager.SpriteBatch;

            spriteBatch.Begin();
            tilemap.Draw(gameTime, spriteBatch);

            string currentText = "ESC to open Menu";
            Vector2 size = PixelFont.SizeOf(currentText, FontSize.Medium);
            PixelFont.DrawString(spriteBatch, FontSize.Medium, new Vector2(width / 2 - size.X / 2, height - size.Y), Color.White, currentText);

            spriteBatch.End();
        }
    }
}
