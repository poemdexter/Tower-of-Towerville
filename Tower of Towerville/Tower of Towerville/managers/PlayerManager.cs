using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tower_of_Towerville.framework;
using Tower_of_Towerville.entities.components;
using Microsoft.Xna.Framework.Graphics;
using Tower_of_Towerville.entities.actions;

namespace Tower_of_Towerville.managers
{
    public static class PlayerManager
    {
        public static Entity Player { get; set; }

        public static void initialize(Texture2D sprite)
        {
            Player = new Entity();
            Player.AddComponent(new Animation(sprite, 1, false, SpriteEffects.None));
            Player.AddComponent(new Position(8,14));
            Player.AddAction(new ChangeDirectionOfAnimation());
            Player.AddAction(new ChangeDeltaPosition());
        }
    }
}
