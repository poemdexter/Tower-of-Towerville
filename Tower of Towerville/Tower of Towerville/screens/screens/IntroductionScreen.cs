using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tower_of_Towerville.screens.framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tower_of_Towerville.screens.screens
{
    class IntroductionScreen : GameScreen
    {
        public IntroductionScreen() { }

        public override void HandleInput(InputState input)
        {
            if (input.IsNewKeyPress(Keys.Enter) || input.IsNewKeyPress(Keys.Space))
            {
                // move on to gameplay
                screenManager.AddScreen(new MainGameScreen());
                screenManager.RemoveScreen(this);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice graphics = screenManager.GraphicsDevice;
            SpriteBatch spriteBatch = screenManager.SpriteBatch;
            SpriteFont font = screenManager.Font;

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null);

            // draw wall of text for story
            int x = 0;
            foreach (string words in storyStrings)
            {
                spriteBatch.DrawString(font, words, new Vector2(20, 20 + x), Color.White, 0, Vector2.Zero, 2f, SpriteEffects.None, 0);
                x += 20;
            }

            string text = "Press Spacebar to Begin...";
            spriteBatch.DrawString(font, text, new Vector2(graphics.Viewport.Width - 220,graphics.Viewport.Height - 20), Color.White, 0, Vector2.Zero, 2f, SpriteEffects.None, 0);
            spriteBatch.End();
        }

        public List<string> storyStrings = new List<string> 
        { 
            "Once upon a time, there was a town called Towerville.  It was awesome all the time.",
            "Once upon a time, there was a town called Towerville.  It was awesome all the time.",
            "Once upon a time, there was a town called Towerville.  It was awesome all the time.",
            "Once upon a time, there was a town called Towerville.  It was awesome all the time.",
            "Once upon a time, there was a town called Towerville.  It was awesome all the time.",
            "Once upon a time, there was a town called Towerville.  It was awesome all the time.",
            "Once upon a time, there was a town called Towerville.  It was awesome all the time.",
            "Once upon a time, there was a town called Towerville.  It was awesome all the time.",
            "Once upon a time, there was a town called Towerville.  It was awesome all the time.",
            "Once upon a time, there was a town called Towerville.  It was awesome all the time.",
            "Once upon a time, there was a town called Towerville.  It was awesome all the time.",
            "Once upon a time, there was a town called Towerville.  It was awesome all the time.",
            "Once upon a time, there was a town called Towerville.  It was awesome all the time.",
            "Once upon a time, there was a town called Towerville.  It was awesome all the time.",
            "Once upon a time, there was a town called Towerville.  It was awesome all the time.",
            "Once upon a time, there was a town called Towerville.  It was awesome all the time.",
            "Once upon a time, there was a town called Towerville.  It was awesome all the time.",
            "Once upon a time, there was a town called Towerville.  It was awesome all the time.",
            "Once upon a time, there was a town called Towerville.  It was awesome all the time.",
            "Once upon a time, there was a town called Towerville.  It was awesome all the time.",
            "Once upon a time, there was a town called Towerville.  It was awesome all the time.",
            "Once upon a time, there was a town called Towerville.  It was awesome all the time.",
            "Once upon a time, there was a town called Towerville.  It was awesome all the time.",
            "Once upon a time, there was a town called Towerville.  It was awesome all the time.",
            "Once upon a time, there was a town called Towerville.  It was awesome all the time.",
            "Once upon a time, there was a town called Towerville.  It was awesome all the time.",
            "Once upon a time, there was a town called Towerville.  It was awesome all the time.",
            "Once upon a time, there was a town called Towerville.  It was awesome all the time.",
            "Once upon a time, there was a town called Towerville.  It was awesome all the time.",
            "Once upon a time, there was a town called Towerville.  It was awesome all the time.",
            "Once upon a time, there was a town called Towerville.  It was awesome all the time."
        };
    }
}
