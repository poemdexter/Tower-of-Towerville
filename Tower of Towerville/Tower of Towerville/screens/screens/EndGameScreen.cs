using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tower_of_Towerville.screens.framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Tower_of_Towerville.screens.screens
{
    class EndGameScreen : GameScreen
    {
        List<MenuEntry> menuEntries = new List<MenuEntry>();
        int selectedEntry = 1;
        Texture2D backgroundTexture;

        public EndGameScreen() 
        {
            menuEntries.Add(new MenuEntry("Yes"));
            menuEntries.Add(new MenuEntry("No"));
            menuEntries[selectedEntry].Active = true;
        }

        public override void LoadContent()
        {
            backgroundTexture = screenManager.Game.Content.Load<Texture2D>("screen/endgame_bg");
        }

        public override void HandleInput(InputState input)
        {
            if (input.IsNewKeyPress(Keys.Left))
            {
                selectedEntry--;

                if (selectedEntry < 0)
                    selectedEntry = menuEntries.Count - 1;
            }
            if (input.IsNewKeyPress(Keys.Right))
            {
                selectedEntry++;

                if (selectedEntry >= menuEntries.Count)
                    selectedEntry = 0;
            }
            if (input.IsNewKeyPress(Keys.Enter) || input.IsNewKeyPress(Keys.Space))
            {
                switch (selectedEntry)
                {
                    case (int)EndGameEntry.Yes:
                        screenManager.Game.Exit();
                        break;
                    case (int)EndGameEntry.No:
                        screenManager.RemoveScreen(this);
                        break;
                }
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

            for (int i = 0; i < menuEntries.Count; i++)
            {
                menuEntries[i].Active = (i == selectedEntry) ? true : false;
            }
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            GraphicsDevice graphics = screenManager.GraphicsDevice;
            SpriteBatch spriteBatch = screenManager.SpriteBatch;
            SpriteFont font = screenManager.Font;

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null);

            // draw background
            float scale = 4f;
            spriteBatch.Draw(backgroundTexture, new Vector2(20,255), backgroundTexture.Bounds, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f); 

            // draw title
            string titleText = "Are you sure you want to exit game?";
            spriteBatch.DrawString(font, titleText, new Vector2(graphics.Viewport.Width / 2, 300), Color.White, 0, font.MeasureString(titleText) / 2, 4f, SpriteEffects.None, 0);

            // draw options
            int x = 0;
            foreach (MenuEntry entry in menuEntries)
            {
                spriteBatch.DrawString(font, entry.Text, new Vector2(250 + x, 350), entry.getColor(), 0, Vector2.Zero, 4f, SpriteEffects.None, 0);
                x += 200;
            }

            spriteBatch.End();
        }
    }
}
