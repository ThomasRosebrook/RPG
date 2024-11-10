using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using RPG.Interactables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RPG
{
    public class Tilemap
    {
        /// <summary>
        /// the dimensions of the tilemap
        /// </summary>
        int _tileWidth, _tileHeight, _mapWidth, _mapHeight;

        /// <summary>
        /// the tileset texture
        /// </summary>
        Texture2D _tilesetTexture;

        /// <summary>
        /// the tile info in the tileset
        /// </summary>
        Rectangle[] _tiles;

        /// <summary>
        /// the tile map data
        /// </summary>
        int[,] _map;


        /// <summary>
        /// the filename of the map file
        /// </summary>
        string _filename;

        List<IInteractable> interactables = new List<IInteractable>();

        public List<NPC> NPCs = new List<NPC>();


        public Tilemap(string filename)
        {
            _filename = filename;
        }

        public void LoadContent(ContentManager content)
        {
            string data = File.ReadAllText(Path.Join(content.RootDirectory, _filename));
            var lines = data.Split('\n');
            // first line is the tileset filename
            var tilesetFilename = lines[0].Trim();
            _tilesetTexture = content.Load<Texture2D>(tilesetFilename);

            // second line is the tile size
            var secondLine = lines[1].Split(',');
            _tileWidth = int.Parse(secondLine[0]);
            _tileHeight = int.Parse(secondLine[1]);

            // now we can determine our tile bounds
            int tilesetColumns = _tilesetTexture.Width / _tileWidth;
            int tilesetRows = _tilesetTexture.Height / _tileHeight;
            _tiles = new Rectangle[tilesetColumns * tilesetRows];

            for (int y = 0; y < tilesetRows; y++)
            {
                for (int x = 0; x < tilesetColumns; x++)
                {
                    int index = y * tilesetColumns + x;
                    _tiles[index] = new Rectangle(x * _tileWidth, y * _tileHeight, _tileWidth, _tileHeight);
                }
            }

            // third line is the map size
            var thirdLine = lines[2].Split(",");
            _mapWidth = int.Parse(thirdLine[0]);
            _mapHeight = int.Parse(thirdLine[1]);

            // initialize the map array
            _map = new int[_mapWidth, _mapHeight];

            // read the map data starting from the fourth line
            for (int y = 0; y < _mapHeight; y++)
            {
                var mapLine = lines[3 + y].Split(',');
                for (int x = 0; x < _mapWidth; x++)
                {
                    _map[x, y] = int.Parse(mapLine[x]);
                }
            }

            int postTilesIndex = 3 + _mapHeight;

            if (lines.Count() < postTilesIndex) return;

            int numInteractables = int.Parse(lines[postTilesIndex]);

            for (int i = 0; i < numInteractables; i++)
            {
                var line = lines[postTilesIndex + i + 1].Split(',');

                IInteractable interactable = null;

                if (line[0] == "d")
                {
                    DialogueObject dObj = new DialogueObject(line[3], line[4]);
                    dObj.SetPosition(new Vector2(float.Parse(line[1]), float.Parse(line[2])));
                    interactable = dObj;
                }
                else if (line[0] == "o")
                {

                }

                if (interactable != null) interactables.Add(interactable);

            }

            int postInteractablesIndex = numInteractables + postTilesIndex + 1;
            if (lines.Count() < postInteractablesIndex) return;

            int numNPCs = int.Parse(lines[postInteractablesIndex]);

            for (int i = 0; i < numNPCs; i++)
            {
                var line = lines[postInteractablesIndex + i + 1].Split(',');

                NPC npc = null;

                if (line[0] == "s")
                {
                    Enemy enemy = new Slime();
                    npc = new NPC(enemy, new Vector2(float.Parse(line[1]), float.Parse(line[2])));
                    //interactable = dObj;
                }
                else if (line[0] == "b")
                {
                    Enemy enemy = new Bat();
                    npc = new NPC(enemy, new Vector2(float.Parse(line[1]), float.Parse(line[2])));
                }

                if (npc != null) NPCs.Add(npc);

            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            for (int y = 0; y < _mapHeight; y++)
            {
                for (int x = 0; x < _mapWidth; x++)
                {
                    int index = _map[x, y];
                    if (index == -1) continue;
                    spriteBatch.Draw(_tilesetTexture, new Vector2(x * _tileWidth, y * _tileHeight), _tiles[index], Color.White);
                }
            }
        }
        public int GetTile(int x, int y)
        {
            if (x < 0 || x >= _mapWidth || y < 0 || y >= _mapHeight)
            {
                return -1;
            }
            return _map[x, y];
        }

        public IInteractable GetInteractable(Vector2 position)
        {
            if (interactables.Count == 0 || position.X < 0 || position.X >= _mapWidth || position.Y < 0 || position.Y >= _mapHeight)
            {
                return null;
            }
            return interactables.Find(i => i.GetPosition() == position);
        }

        public NPC GetNPC(Vector2 position)
        {
            if (NPCs.Count == 0 || position.X < 0 || position.X >= _mapWidth || position.Y < 0 || position.Y >= _mapHeight)
            {
                return null;
            }
            return NPCs.Find(i => i.GetPosition() == position && i.IsAlive);
        }
    }
}
