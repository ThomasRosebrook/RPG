using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.ScreenManagement
{
    public class InputManager
    {
        GamePadState currentGamePadState;
        GamePadState previousGamePadState;

        KeyboardState currentKeyboardState;
        KeyboardState previousKeyboardState;

        MouseState currentMouseState;
        MouseState previousMouseState;

        public bool Escape { get; private set; } = false;

        public bool Space { get; private set; } = false;

        public void Update ()
        {
            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();

            previousGamePadState = currentGamePadState;
            currentGamePadState = GamePad.GetState(0);

            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            Space = false;
            if (currentGamePadState.Buttons.A == ButtonState.Pressed && previousGamePadState.Buttons.A == ButtonState.Released
                || currentKeyboardState.IsKeyDown(Keys.Space) && !previousKeyboardState.IsKeyDown(Keys.Space))
            {
                Space = true;
            }

            Escape = false;
            if (currentGamePadState.Buttons.Back == ButtonState.Pressed && previousGamePadState.Buttons.Back == ButtonState.Released 
                || currentKeyboardState.IsKeyDown(Keys.Escape) && !previousKeyboardState.IsKeyDown(Keys.Escape))
            {
                Escape = true;
            }
        }
    }
}
