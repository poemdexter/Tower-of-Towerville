using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tower_of_Towerville.screens.framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tower_of_Towerville.dungeon;

namespace Tower_of_Towerville.screens.screens
{
    enum EnvTiles
    {
        WallExp = 1,
        WallReg = 2,
        Floor = 3
    }

    class MainGameScreen : GameScreen
    {
        Dictionary<string, Texture2D> spriteDict;
        Tower tower;
        private const int XtoCenter = 88;

        public MainGameScreen()
        {

        }

        public override void LoadContent()
        {
            loadSpriteDictionary();
            tower = new Tower(screenManager.Game.Content);
        }

        public override void HandleInput(InputState input)
        {
            if (input.IsNewKeyPress(Keys.NumPad0))
            { }
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
            Texture2D texture;
            for (int x = 0; x < tower.floorplan.Length; x++)
            {
                for (int y = 0; y < tower.floorplan[0].Length; y++)
                {
                    switch (tower.floorplan[x][y])
                    {
                        case (int)EnvTiles.WallExp:
                            texture = spriteDict["wall_exp"];
                            spriteBatch.Draw(texture, new Vector2(x * (4f * texture.Width) + XtoCenter, y * (4f * texture.Height)), null, Color.White, 0f, Vector2.Zero, 4f, SpriteEffects.None, 0f);
                            break;
                        case (int)EnvTiles.WallReg:
                            texture = spriteDict["wall_reg"];
                            spriteBatch.Draw(texture, new Vector2(x * (4f * texture.Width) + XtoCenter, y * (4f * texture.Height)), null, Color.White, 0f, Vector2.Zero, 4f, SpriteEffects.None, 0f);
                            break;
                        case (int)EnvTiles.Floor:
                            texture = spriteDict["floor"];
                            spriteBatch.Draw(texture, new Vector2(x * (4f * texture.Width) + XtoCenter, y * (4f * texture.Height)), null, Color.White, 0f, Vector2.Zero, 4f, SpriteEffects.None, 0f);
                            break;
                    }
                }
            }
            spriteBatch.End();
        }

        private void loadSpriteDictionary()
        {
            spriteDict = new Dictionary<string, Texture2D>();

            spriteDict.Add("wizard", screenManager.Game.Content.Load<Texture2D>("character/wizard"));
            spriteDict.Add("floor", screenManager.Game.Content.Load<Texture2D>("environment/floor"));
            spriteDict.Add("wall_exp", screenManager.Game.Content.Load<Texture2D>("environment/wall_exp"));
            spriteDict.Add("wall_reg", screenManager.Game.Content.Load<Texture2D>("environment/wall_reg"));
        }
    }
}
