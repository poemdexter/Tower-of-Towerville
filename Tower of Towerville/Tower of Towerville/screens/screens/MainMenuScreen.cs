using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tower_of_Towerville.screens.framework;
using Microsoft.Xna.Framework.Input;

namespace Tower_of_Towerville.screens.screens
{
    public enum Entry
    {
        NewGame,
        ContinueGame,
        Exit
    }

    class MainMenuScreen : GameScreen
    {
        private const string titleText = "Tower of Towerville";

        List<MenuEntry> menuEntries = new List<MenuEntry>();
        int selectedEntry = 0;

        public MainMenuScreen()
        {
            menuEntries.Add(new MenuEntry("New Game"));
            menuEntries.Add(new MenuEntry("Continue Game"));
            menuEntries.Add(new MenuEntry("Exit"));
            menuEntries[0].Active = true;
        }

        // handle key presses
        public override void HandleInput(InputState input)
        {
            if (input.IsNewKeyPress(Keys.Up))
            {
                selectedEntry--;

                if (selectedEntry < 0)
                    selectedEntry = menuEntries.Count - 1;
            }
            if (input.IsNewKeyPress(Keys.Down))
            {
                selectedEntry++;

                if (selectedEntry >= menuEntries.Count)
                    selectedEntry = 0;
            }
            if (input.IsNewKeyPress(Keys.Enter))
            {
                switch (selectedEntry)
                {
                    case (int)Entry.NewGame:
                        screenManager.AddScreen(new NameInputScreen(this));
                        break;
                    case (int)Entry.ContinueGame:
                        break;
                    case (int)Entry.Exit:
                        screenManager.Game.Exit();
                        break;
                }
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

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice graphics = screenManager.GraphicsDevice;
            SpriteBatch spriteBatch = screenManager.SpriteBatch;
            SpriteFont font = screenManager.Font;

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null);

            // draw title
            spriteBatch.DrawString(font, titleText, new Vector2(graphics.Viewport.Width / 2, 100), Color.White, 0, font.MeasureString(titleText) / 2, 4f, SpriteEffects.None, 0);

            // draw options
            int x = 0;
            foreach (MenuEntry entry in menuEntries)
            {
                spriteBatch.DrawString(font, entry.Text, new Vector2(50, 600 + x), entry.getColor(), 0, Vector2.Zero, 2f, SpriteEffects.None, 0);
                x += 30;
            }

            spriteBatch.End();
        }

        class MenuEntry
        {
            public bool Active { get; set; }
            public string Text { get; set; }

            public MenuEntry(string text)
            {
                Text = text;
                Active = false;
            }

            public Color getColor()
            {
                return (Active) ? Color.Yellow : Color.White;
            }
        }
    }
}
