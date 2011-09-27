using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Tower_of_Towerville.screenStuff.screenManager
{
    public enum ScreenState
    {
        TransitionOn,
        Active,
        TransitionOff,
        Hidden,
    }

    public abstract class GameScreen
    {
        // will screens underneith transition off?
        public bool IsPopup
        {
            get { return isPopup; }
            protected set { isPopup = value; }
        }

        bool isPopup = false;

        // how long to transition on when activated?
        public TimeSpan TransitionOnTime
        {
            get { return transitionOnTime; }
            protected set { transitionOnTime = value; }
        }

        TimeSpan transitionOnTime = TimeSpan.Zero;

        // how long to transition off when deactivated?
        public TimeSpan TransitionOffTime
        {
            get { return transitionOffTime; }
            protected set { transitionOffTime = value; }
        }

        TimeSpan transitionOffTime = TimeSpan.Zero;

        // get current position of screen transition
        // 0 -> fully active
        // ...
        // 1 -> transitioned off completely
        public float TransitionPosition
        {
            get { return transitionPosition; }
            protected set { transitionPosition = value; }
        }

        float transitionPosition = 1;

        // current alpha of the screen transition
        public float TransitionAlpha
        {
            get { return 1f - TransitionPosition; }
        }

        // gets current screen transition state
        public ScreenState ScreenState
        {
            get { return screenState; }
            protected set { screenState = value; }
        }

        ScreenState screenState = ScreenState.TransitionOn;

        // if transitioning off, is it going completely off?
        public bool IsExiting
        {
            get { return isExiting; }
            protected internal set { isExiting = value; }
        }

        bool isExiting = false;

        // is screen active and can respond to user input?
        public bool IsActive
        {
            get
            {
                return !otherScreenHasFocus &&
                       (screenState == ScreenState.TransitionOn ||
                        screenState == ScreenState.Active);
            }
        }

        bool otherScreenHasFocus;

        // get the screen manager this screen belongs to
        public ScreenManager ScreenMngr
        {
            get { return screenManager; }
            internal set { screenManager = value; }
        }

        ScreenManager screenManager;

        public virtual void LoadContent() { }
        public virtual void UnloadContent() { }

        /// <summary>
        /// Allows the screen to handle user input. Unlike Update, this method
        /// is only called when the screen is active, and not when some other
        /// screen has taken the focus.
        /// </summary>
        public virtual void HandleInput(InputState input) { }

        public virtual void Draw(GameTime gameTime) { }

        /// <summary>
        /// Allows the screen to run logic, such as updating the transition position.
        /// Unlike HandleInput, this method is called regardless of whether the screen
        /// is active, hidden, or in the middle of a transition.
        /// </summary>
        public virtual void Update(GameTime gameTime, bool otherScreenHasFocus,
                                                      bool coveredByOtherScreen)
        {
            this.otherScreenHasFocus = otherScreenHasFocus;

            if (isExiting)
            {
                // If the screen is going away to die, it should transition off.
                screenState = ScreenState.TransitionOff;

                if (!UpdateTransition(gameTime, transitionOffTime, 1))
                {
                    // When the transition finishes, remove the screen.
                    ScreenMngr.RemoveScreen(this);
                }
            }
            else if (coveredByOtherScreen)
            {
                // If the screen is covered by another, it should transition off.
                if (UpdateTransition(gameTime, transitionOffTime, 1))
                {
                    // Still busy transitioning.
                    screenState = ScreenState.TransitionOff;
                }
                else
                {
                    // Transition finished!
                    screenState = ScreenState.Hidden;
                }
            }
            else
            {
                // Otherwise the screen should transition on and become active.
                if (UpdateTransition(gameTime, transitionOnTime, -1))
                {
                    // Still busy transitioning.
                    screenState = ScreenState.TransitionOn;
                }
                else
                {
                    // Transition finished!
                    screenState = ScreenState.Active;
                }
            }
        }

        /// <summary>
        /// Helper for updating the screen transition position.
        /// </summary>
        bool UpdateTransition(GameTime gameTime, TimeSpan time, int direction)
        {
            // How much should we move by?
            float transitionDelta;

            if (time == TimeSpan.Zero)
                transitionDelta = 1;
            else
                transitionDelta = (float)(gameTime.ElapsedGameTime.TotalMilliseconds /
                                          time.TotalMilliseconds);

            // Update the transition position.
            transitionPosition += transitionDelta * direction;

            // Did we reach the end of the transition?
            if (((direction < 0) && (transitionPosition <= 0)) ||
                ((direction > 0) && (transitionPosition >= 1)))
            {
                transitionPosition = MathHelper.Clamp(transitionPosition, 0, 1);
                return false;
            }

            // Otherwise we are still busy transitioning.
            return true;
        }

        /// <summary>
        /// Tells the screen to go away. Unlike ScreenManager.RemoveScreen, which
        /// instantly kills the screen, this method respects the transition timings
        /// and will give the screen a chance to gradually transition off.
        /// </summary>
        public void ExitScreen()
        {
            if (TransitionOffTime == TimeSpan.Zero)
            {
                // If the screen has a zero transition time, remove it immediately.
                ScreenMngr.RemoveScreen(this);
            }
            else
            {
                // Otherwise flag that it should transition off and then exit.
                isExiting = true;
            }
        }
    }
}


