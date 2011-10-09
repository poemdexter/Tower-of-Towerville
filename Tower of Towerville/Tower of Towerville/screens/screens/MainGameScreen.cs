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
    class MainGameScreen : GameScreen
    {
        Dictionary<string, Texture2D> spriteDict;

        public MainGameScreen()
        {
 
        }

        public override void LoadContent()
        {
            loadSpriteDictionary();
        }

        public override void HandleInput(InputState input)
        {
            if (input.IsNewKeyPress(Keys.NumPad0))
            {}
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice graphics = screenManager.GraphicsDevice;
            SpriteBatch spriteBatch = screenManager.SpriteBatch;
            SpriteFont font = screenManager.Font;

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null);

            // draw things
            Texture2D texture = spriteDict["floor"];
            for (int x = 0; x < 17; x++)
            {
                for (int y = 0; y < 17; y++)
                {
                    spriteBatch.Draw(texture, new Vector2(x * (4f * texture.Width), y * (4f * texture.Height)), null, Color.White, 0f, Vector2.Zero, 4f, SpriteEffects.None, 0f);
                }
            }
            spriteBatch.End();
        }

        private void loadSpriteDictionary()
        {
            spriteDict = new Dictionary<string, Texture2D>();

            spriteDict.Add("wizard", screenManager.Game.Content.Load<Texture2D>("character/wizard"));
            spriteDict.Add("floor", screenManager.Game.Content.Load<Texture2D>("environment/floor"));
        }
    }
}
