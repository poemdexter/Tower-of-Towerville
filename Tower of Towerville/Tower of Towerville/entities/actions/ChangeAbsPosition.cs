using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tower_of_Towerville.framework;
using Tower_of_Towerville.entities.action_args;
using Tower_of_Towerville.entities.components;
using Microsoft.Xna.Framework;

namespace Tower_of_Towerville.entities.actions
{
    class ChangeAbsPosition : EntityAction
    {
        public ChangeAbsPosition()
        {
            this.Name = "ChangeAbsPosition";
        }

        public override void Do(ActionArgs args)
        {
            if (this.Entity != null && args != null && args is ChangePositionArgs)
            {
                Position position = this.Entity.GetComponent("Position") as Position;
                if (position != null)
                {
                    Vector2 delta = ((ChangePositionArgs)args).Delta;
                    position.X = (int)delta.X;
                    position.Y = (int)delta.Y;
                }
            }
        }
    }
}
