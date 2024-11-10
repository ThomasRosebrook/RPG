using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using RPG.ScreenManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;

namespace RPG.Screens
{
    public class WorldScreen : GameScreen
    {
        private ContentManager _content;
        int[] collisions = new int[] { 301, 251, 284, 59, 60, 61, 62, 63, 64, 653, 654, 655, 656, 57, 56, 1239, 1240, 1241, 1321, 1322, 1323, 1324, 1325, 1326, 1327, 1328, 1409, 1410, 1411, 233, 88, 300, 90, 1420, 1421, 1422, 1423, 1424, 1425, 707, 708, 675, 643, 610, 609, 1272, 1273, 1274, 1354, 1355, 1356, 1357, 1358, 1359, 1360, 1361, 645, 647, 1316, 200, 121, 55, 123, 1453, 1454, 1455, 1456, 1457, 1458, 673, 672, 639, 607, 574, 575, 1305, 1306, 1307, 1420, 1421, 1422, 1423, 1424, 1425, 1426, 1427, 409, 1170, 1342, 1346, 49, 50, 51, 52, 53, 1426, 1427, 304, 305, 306, 307, 308, 309, 310, 311, 1338, 1339, 1340, 1453, 1454, 1455, 1456, 1457, 1458, 1459, 1460, 1171, 125, 1375, 1379, 82, 83, 84, 85, 86, 1459, 1460, 337, 338, 339, 340, 341, 342, 343, 344, 1371, 1372, 1373, 1244, 1245, 1246, 1344, 40, 41, 42, 43, 44, 45, 1408, 1412, 115, 116, 117, 118, 119, 266, 267, 172, 173, 174, 175, 176, 47, 178, 179, 1404, 1405, 1406, 1310, 1311, 1312, 370, 371, 372, 373, 412, 413, 414, 1474, 1475, 148, 149, 150, 151, 152, 268, 559, 205, 206, 207, 208, 209, 80, 211, 212, 1243, 1247, 341, 492, 493, 406, 374, 375, 376, 377, 524, 525, 526, 919, 913, 181, 182, 183, 184, 185, 592, 625, 1338, 1339, 1340, 1371, 242, 113, 244, 245, 1276, 1280, 342, 127, 128, 129, 130, 92, 93, 94, 95, 96, 97, 911, 879, 214, 215, 216, 217, 218, 780, 814, 271, 272, 273, 274, 275, 146, 277, 278, 1309, 1313, 343, 344, 379, 380, 381, 1476, 1477, 408, 1168, 458, 459, 460, 405, 247, 248, 249, 250, 658, 412, 413, 414, 304, 305, 313, 314, 315, 316, 410, 407, 1343, 1345, 1081, 1082, 404, 339, 340, 346, 347, 348, 1478, 1169, 337, 338,280,281,282,283,657,403};
        private int width;
        private int height;
        private Player player;
        Tilemap tilemap;
        private Interactable interact; 
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

        public static int CurrentTileMap = 4;

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
            player = new Player() { Position = new Vector2(8,8) * 60 };
            player.LoadContent(_content);

            base.Activate();
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
                player.Update(gameTime);
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
            if (input.Enter)
            {
                if(InteractionCheck(player, input.Direction))
                {
                    //who knows
                }
            }

            if (player.CanMove && (CollisionCheck(player, new Vector2(0, input.Direction.Y)) || CollisionCheck(player, new Vector2(input.Direction.X, 0))) && CollisionCheck(player, input.Direction))
            {
                player.Move(input.Direction);
            }



        }
        public bool CollisionCheck(Player p, Vector2 direction)
        {
            if (direction.X == 0 && direction.Y == 0) return false;

            int targetX = (int)p.Position.X / 60 + (int)direction.X;
            int targetY = (int)p.Position.Y / 60 + (int)direction.Y;

            int tileFacing = tilemap.GetTile(targetX, targetY);
            
            if(tileFacing != -1) return !Array.Exists(collisions, element => element == tileFacing);

            return false;
        }
        public bool InteractionCheck(Player p, Vector2 direction)
        {
            int targetX = (int)p.Position.X / 60 + (int)direction.X;
            int targetY = (int)p.Position.Y / 60 + (int)direction.Y;

            int tileFacing = tilemap.GetTile(targetX, targetY);
            return interact.CanInteract(tileFacing);
        }

        public override void Draw(GameTime gameTime)
        {
            ScreenManager.GraphicsDevice.Clear(ClearOptions.Target, Color.Gray, 0, 0);

            var spriteBatch = ScreenManager.SpriteBatch;

            spriteBatch.Begin();
            tilemap.Draw(gameTime, spriteBatch);

            player.Draw(gameTime, spriteBatch);

            string currentText = "ESC to open Menu";
            Vector2 size = PixelFont.SizeOf(currentText, FontSize.Medium);
            PixelFont.DrawString(spriteBatch, FontSize.Medium, new Vector2(width / 2 - size.X / 2, height - size.Y), Color.White, currentText);

            spriteBatch.End();
        }
        public void openDoor()
        {

        }
    }
}
