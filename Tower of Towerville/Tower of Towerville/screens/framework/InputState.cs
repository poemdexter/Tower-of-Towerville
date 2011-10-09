using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Tower_of_Towerville.screens.framework
{
    public class InputState
    {
        public KeyboardState CurrentKeyboardState;
        public KeyboardState LastKeyboardState;
        private int keyboardElapsedTime;

        public InputState()
        {
            CurrentKeyboardState = new KeyboardState();
            LastKeyboardState = new KeyboardState();
            keyboardElapsedTime = 0;
        }

        public void Update(GameTime gameTime)
        {
            LastKeyboardState = CurrentKeyboardState;
            CurrentKeyboardState = Keyboard.GetState();
            keyboardElapsedTime -= gameTime.ElapsedGameTime.Milliseconds;
        }

        public bool IsNewKeyPress(Keys key)
        {
            if (keyboardElapsedTime <= 0)
            {
                if (CurrentKeyboardState.IsKeyDown(key))
                {
                    keyboardElapsedTime = 200;
                    return true;
                }
            }
            return false;
        }
    }
}
