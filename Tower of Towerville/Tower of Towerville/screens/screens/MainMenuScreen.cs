using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tower_of_Towerville.screens.framework;

namespace Tower_of_Towerville.screens.screens
{
    class MainMenuScreen : GameScreen
    {
        private const string titleText = "Tower of Towerville";
        private const string newText = "New Game";
        private const string continueText = "Continue Game";
        private const string exitText = "Exit";

        public MainMenuScreen()
        {
        }

        public override void HandleInput(InputState input)
        {
            // handle it
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice graphics = screenManager.GraphicsDevice;
            SpriteBatch spriteBatch = screenManager.SpriteBatch;
            SpriteFont font = screenManager.Font;

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null);

            // draw title
            spriteBatch.DrawString(font, titleText, new Vector2(graphics.Viewport.Width / 2, 100), Color.White, 0, font.MeasureString(titleText) / 2, 4f, SpriteEffects.None, 0);

            // draw options
            spriteBatch.DrawString(font, newText, new Vector2(50, 600), Color.White, 0, Vector2.Zero, 2f, SpriteEffects.None, 0);
            spriteBatch.DrawString(font, continueText, new Vector2(50, 630), Color.White, 0, Vector2.Zero, 2f, SpriteEffects.None, 0);
            spriteBatch.DrawString(font, exitText, new Vector2(50, 660), Color.White, 0, Vector2.Zero, 2f, SpriteEffects.None, 0);

            spriteBatch.End();
        }
    }
}
