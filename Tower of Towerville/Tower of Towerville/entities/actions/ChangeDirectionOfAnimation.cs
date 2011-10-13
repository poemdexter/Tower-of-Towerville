using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tower_of_Towerville.framework;
using Tower_of_Towerville.entities.components;
using Tower_of_Towerville.entities.action_args;
using Microsoft.Xna.Framework.Graphics;

namespace Tower_of_Towerville.entities.actions
{
    class ChangeDirectionOfAnimation : EntityAction
    {
        public ChangeDirectionOfAnimation()
        {
            this.Name = "ChangeDirectionOfAnimation";
        }

        public override void Do(ActionArgs args)
        {
            if (this.Entity != null && args != null && args is ChangeDirectionOfAnimationArgs)
            {
                Animation animation = this.Entity.GetComponent("Animation") as Animation;
                if (animation != null)
                {
                    string direction = ((ChangeDirectionOfAnimationArgs)args).Direction;

                    if (direction == "left")
                    {
                        animation.Effects = SpriteEffects.FlipHorizontally;
                    }
                    else if (direction == "right")
                    {
                        animation.Effects = SpriteEffects.None;
                    }
                }
            }
        }
    }
}
