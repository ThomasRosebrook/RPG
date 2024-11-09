using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RPG.ScreenManagement;
using RPG.Screens;

namespace RPG
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Tilemap tilemap;
        private ScreenManager _screenManager;

        int _screenWidth = 900;
        int _screenHeight = 900;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.Title = "RPG";

            _screenManager = new ScreenManager(this);
            Components.Add(_screenManager);

            AddInitialScreens();

            _graphics.PreferredBackBufferWidth = _screenWidth;
            _graphics.PreferredBackBufferHeight = _screenHeight;
        }

        private void AddInitialScreens()
        {
            _screenManager.AddScreen(new MainMenu());

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            tilemap = new Tilemap("Tilemap8.txt");
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            PixelFont.LoadFonts(Content);

            tilemap.LoadContent(Content);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            /*if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();*/

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(32, 18, 8));
            _spriteBatch.Begin();
            tilemap.Draw(gameTime, _spriteBatch);
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}