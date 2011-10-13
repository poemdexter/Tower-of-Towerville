using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tower_of_Towerville.screens.framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tower_of_Towerville.dungeon;
using Tower_of_Towerville.framework;
using Tower_of_Towerville.entities.components;
using Tower_of_Towerville.managers;
using Tower_of_Towerville.entities.action_args;

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
        int torch_elapsedTime, torch_frameTime;
        float scale = 4f;

        public MainGameScreen()
        {

        }

        public override void LoadContent()
        {
            loadSpriteDictionary();
            tower = new Tower(screenManager.Game.Content, spriteDict);
            PlayerManager.initialize(spriteDict["wizard"]);
            torch_elapsedTime = 0;
            torch_frameTime = 75;
        }

        public override void HandleInput(InputState input)
        {
            int x = (int)((Position)PlayerManager.Player.GetComponent("Position")).X;
            int y = (int)((Position)PlayerManager.Player.GetComponent("Position")).Y;

            if (input.IsNewKeyPress(Keys.NumPad1) && (tower.getCurrentFloor())[x - 1][y + 1] == (int)EnvTiles.Floor)
            {
                PlayerManager.Player.DoAction("ChangeDeltaPosition", new ChangePositionArgs(new Vector2(-1, 1)));
                PlayerManager.Player.DoAction("ChangeDirectionOfAnimation", new ChangeDirectionOfAnimationArgs("left"));
            }
            else if (input.IsNewKeyPress(Keys.NumPad4) && (tower.getCurrentFloor())[x - 1][y] == (int)EnvTiles.Floor)
            {
                PlayerManager.Player.DoAction("ChangeDeltaPosition", new ChangePositionArgs(new Vector2(-1, 0)));
                PlayerManager.Player.DoAction("ChangeDirectionOfAnimation", new ChangeDirectionOfAnimationArgs("left"));
            }
            else if (input.IsNewKeyPress(Keys.NumPad7) && (tower.getCurrentFloor())[x - 1][y - 1] == (int)EnvTiles.Floor)
            {
                PlayerManager.Player.DoAction("ChangeDeltaPosition", new ChangePositionArgs(new Vector2(-1, -1)));
                PlayerManager.Player.DoAction("ChangeDirectionOfAnimation", new ChangeDirectionOfAnimationArgs("left"));
            }
            else if (input.IsNewKeyPress(Keys.NumPad8) && (tower.getCurrentFloor())[x][y - 1] == (int)EnvTiles.Floor)
            {
                PlayerManager.Player.DoAction("ChangeDeltaPosition", new ChangePositionArgs(new Vector2(0, -1)));
            }
            else if (input.IsNewKeyPress(Keys.NumPad9) && (tower.getCurrentFloor())[x + 1][y - 1] == (int)EnvTiles.Floor)
            {
                PlayerManager.Player.DoAction("ChangeDeltaPosition", new ChangePositionArgs(new Vector2(1, -1)));
                PlayerManager.Player.DoAction("ChangeDirectionOfAnimation", new ChangeDirectionOfAnimationArgs("right"));
            }
            else if (input.IsNewKeyPress(Keys.NumPad6) && (tower.getCurrentFloor())[x + 1][y] == (int)EnvTiles.Floor)
            {
                PlayerManager.Player.DoAction("ChangeDeltaPosition", new ChangePositionArgs(new Vector2(1, 0)));
                PlayerManager.Player.DoAction("ChangeDirectionOfAnimation", new ChangeDirectionOfAnimationArgs("right"));
            }
            else if (input.IsNewKeyPress(Keys.NumPad3) && (tower.getCurrentFloor())[x + 1][y + 1] == (int)EnvTiles.Floor)
            {
                PlayerManager.Player.DoAction("ChangeDeltaPosition", new ChangePositionArgs(new Vector2(1, 1)));
                PlayerManager.Player.DoAction("ChangeDirectionOfAnimation", new ChangeDirectionOfAnimationArgs("right"));
            }
            else if (input.IsNewKeyPress(Keys.NumPad2) && (tower.getCurrentFloor())[x][y + 1] == (int)EnvTiles.Floor)
            {
                PlayerManager.Player.DoAction("ChangeDeltaPosition", new ChangePositionArgs(new Vector2(0, 1)));
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            torch_elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (torch_elapsedTime > torch_frameTime)
            {
                foreach (Entity torch in tower.torchList)
                {
                    torch.DoAction("NextFrameOfAnimation");
                    torch_elapsedTime = 0;
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice graphics = screenManager.GraphicsDevice;
            SpriteBatch spriteBatch = screenManager.SpriteBatch;
            SpriteFont font = screenManager.Font;

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null);

            // draw tower
            Texture2D texture;
            int[][] floorplan = tower.getCurrentFloor();
            for (int x = 0; x < floorplan.Length; x++)
            {
                for (int y = 0; y < floorplan[0].Length; y++)
                {
                    switch (floorplan[x][y])
                    {
                        case (int)EnvTiles.WallExp:
                            texture = spriteDict["wall_exp"];
                            spriteBatch.Draw(texture, new Vector2(x * (scale * texture.Width) + XtoCenter, y * (scale * texture.Height)), null, Color.White, 0f, Vector2.Zero, 4f, SpriteEffects.None, 0f);
                            break;
                        case (int)EnvTiles.WallReg:
                            texture = spriteDict["wall_reg"];
                            spriteBatch.Draw(texture, new Vector2(x * (scale * texture.Width) + XtoCenter, y * (scale * texture.Height)), null, Color.White, 0f, Vector2.Zero, 4f, SpriteEffects.None, 0f);
                            break;
                        case (int)EnvTiles.Floor:
                            texture = spriteDict["floor"];
                            spriteBatch.Draw(texture, new Vector2(x * (scale * texture.Width) + XtoCenter, y * (scale * texture.Height)), null, Color.White, 0f, Vector2.Zero, 4f, SpriteEffects.None, 0f);
                            break;
                    }
                }
            }

            foreach (Entity torch in tower.torchList)
            {
                int x = (int)((Position)torch.GetComponent("Position")).X;
                int y = (int)((Position)torch.GetComponent("Position")).Y;
                Animation animation = (Animation)torch.GetComponent("Animation");
                spriteBatch.Draw(animation.SourceTexture, new Vector2(x * (scale * animation.SourceRect.Width) + XtoCenter, y * (scale * animation.SourceRect.Height)), animation.SourceRect, Color.White, 0f, Vector2.Zero, scale, animation.Effects, 0f);
            }

            // draw player
            int px = (int)((Position)PlayerManager.Player.GetComponent("Position")).X;
            int py = (int)((Position)PlayerManager.Player.GetComponent("Position")).Y;
            Animation panimation = (Animation)PlayerManager.Player.GetComponent("Animation");
            spriteBatch.Draw(panimation.SourceTexture, new Vector2(px * (scale * panimation.SourceTexture.Width) + XtoCenter, py * (scale * 8)), panimation.SourceRect, Color.White, 0f, Vector2.Zero, scale, panimation.Effects, 0f);
            spriteBatch.End();
        }

        private void loadSpriteDictionary()
        {
            spriteDict = new Dictionary<string, Texture2D>();

            spriteDict.Add("wizard", screenManager.Game.Content.Load<Texture2D>("character/wizard"));
            spriteDict.Add("floor", screenManager.Game.Content.Load<Texture2D>("environment/floor"));
            spriteDict.Add("wall_exp", screenManager.Game.Content.Load<Texture2D>("environment/wall_exp"));
            spriteDict.Add("wall_reg", screenManager.Game.Content.Load<Texture2D>("environment/wall_reg"));
            spriteDict.Add("wall_torch", screenManager.Game.Content.Load<Texture2D>("environment/wall_torch"));
            spriteDict.Add("stairs_up", screenManager.Game.Content.Load<Texture2D>("environment/stairs_up"));
        }
    }
}
