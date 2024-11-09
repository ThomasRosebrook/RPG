using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace RPG.ScreenManagement
{
    public class ScreenManager : DrawableGameComponent
    {
        public SpriteBatch SpriteBatch { get; private set; }

        public SpriteFont Font { get; private set; }

        List<GameScreen> _screens = new List<GameScreen>();
        List<GameScreen> _tempScreens = new List<GameScreen>();

        ContentManager content;
        InputManager input = new InputManager();

        bool isInitialized = false;

        public ScreenManager(Game game) : base(game)
        {
            content = new ContentManager(game.Services, "Content");
        }

        public override void Initialize()
        {
            base.Initialize();
            isInitialized = true;
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            Font = content.Load<SpriteFont>("Arial");

            foreach (var screen in _screens)
            {
                screen.Activate();
            }
        }

        protected override void UnloadContent()
        {
            foreach (var screen in _screens)
            {
                screen.Unload();
            }
        }

        public override void Update(GameTime gameTime)
        {
            input.Update();

            _tempScreens.Clear();
            _tempScreens.AddRange(_screens);

            bool unfocused = !Game.IsActive;
            bool covered = false;

            foreach (GameScreen screen in _tempScreens)
            {
                screen.Update(gameTime, unfocused, covered);

                if (screen.ScreenState == ScreenState.Active)
                {
                    if (!unfocused)
                    {
                        screen.HandleInput(gameTime, input);
                        unfocused = true;
                    }

                    if (!screen.IsPopup) covered = true;
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (var screen in _screens)
            {
                if (screen.ScreenState == ScreenState.Hidden) continue;

                screen.Draw(gameTime);
            }
        }

        public void AddScreen (GameScreen screen)
        {
            screen.ScreenManager = this;
            screen.IsExiting = false;

            if (isInitialized) screen.Activate();
            _screens.Add(screen);
        }

        public void RemoveScreen (GameScreen screen)
        {
            if (isInitialized) screen.Unload();

            _screens.Remove(screen);
            _tempScreens.Remove(screen);
        }

        public GameScreen[] GetScreens()
        {
            return _screens.ToArray();
        }
    }

    public enum ScreenState
    {
        Inactive,
        Active,
        Hidden
    }
}
