using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Tower_of_Towerville.screenStuff.screenManager
{
    public class InputState
    {
        public KeyboardState CurrentKeyboardState;
        public KeyboardState LastKeyboardState;

        public InputState()
        { 
        }

        public void Update()
        {
            LastKeyboardState = CurrentKeyboardState;
            CurrentKeyboardState = Keyboard.GetState();
        }

        public bool isNewKeyPressed(Keys key)
        {
            return (CurrentKeyboardState.IsKeyDown(key) && LastKeyboardState.IsKeyUp(key));
        }

        public bool IsMenuSelect()
        {
            return isNewKeyPressed(Keys.Enter);
        }

        public bool IsMenuCancel()
        {
            return isNewKeyPressed(Keys.Escape);
        }

        public bool IsMenuUp()
        {
            return isNewKeyPressed(Keys.Up);
        }

        public bool IsMenuDown()
        {
            return isNewKeyPressed(Keys.Down);
        }
    }
}
