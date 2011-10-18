using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tower_of_Towerville.screens.framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Tower_of_Towerville.util;

namespace Tower_of_Towerville.screens.screens
{
    class NameInputScreen : GameScreen
    {
        private const string titleText = "Enter Name:";
        private StringBuilder keyboardInput;
        private KeyboardStringBuilder keyboardStringBuilder;
        private GameScreen ParentScreen;
        Texture2D backgroundTexture;

        public NameInputScreen(GameScreen parentScreen)
        {
            keyboardInput = new StringBuilder();
            keyboardStringBuilder = new KeyboardStringBuilder();
            ParentScreen = parentScreen;
        }

        public override void LoadContent()
        {
            backgroundTexture = screenManager.Game.Content.Load<Texture2D>("screen/nameinput_bg");
        }

        public override void HandleInput(InputState input)
        {
            if (input.IsNewKeyPress(Keys.Enter) && keyboardInput.Length > 0)
            {
                // accept name and move on to intro screen
                screenManager.AddScreen(new IntroductionScreen());
                screenManager.RemoveScreen(this);
                screenManager.RemoveScreen(ParentScreen);
            }
            if (input.IsNewKeyPress(Keys.Escape))
            {
                screenManager.RemoveScreen(this);
            }
        }

        // update menu entry to signal which is selected
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            keyboardStringBuilder.Process(Keyboard.GetState(), gameTime, keyboardInput);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice graphics = screenManager.GraphicsDevice;
            SpriteBatch spriteBatch = screenManager.SpriteBatch;
            SpriteFont font = screenManager.Font;

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null);

            // draw background
            float scale = 4f;
            spriteBatch.Draw(backgroundTexture, new Vector2(graphics.Viewport.Width / 2, 310), backgroundTexture.Bounds, Color.White, 0f, new Vector2(backgroundTexture.Width / 2, backgroundTexture.Height / 2), scale, SpriteEffects.None, 0f);
            // draw title
            spriteBatch.DrawString(font, titleText, new Vector2(graphics.Viewport.Width / 2, 300), Color.White, 0, font.MeasureString(titleText) / 2, 4f, SpriteEffects.None, 0);
            // draw current name
            spriteBatch.DrawString(font, keyboardInput, new Vector2(graphics.Viewport.Width / 2, 330), Color.White, 0, font.MeasureString(keyboardInput) / 2, 4f, SpriteEffects.None, 0);
            spriteBatch.End();
        }
    }
}
