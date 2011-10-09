using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Tower_of_Towerville.managers;
using Tower_of_Towerville.screens.screens;

namespace Tower_of_Towerville
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;

        private int windowHeight = 720;
        private int windowWidth = 720;

        ScreenManager screenManager;

        public Game1()
        {
            Content.RootDirectory = "Content";
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = windowHeight;
            graphics.PreferredBackBufferWidth = windowWidth;

            screenManager = new ScreenManager(this);

            Components.Add(screenManager);

            // Activate the first screens
            screenManager.AddScreen(new MainMenuScreen());
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent() { }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            base.Draw(gameTime);
        }
    }
}
