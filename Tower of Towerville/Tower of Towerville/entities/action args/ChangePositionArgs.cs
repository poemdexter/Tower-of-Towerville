using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tower_of_Towerville.framework;
using Microsoft.Xna.Framework;

namespace Tower_of_Towerville.entities.action_args
{
    class ChangePositionArgs : ActionArgs
    {
        public Vector2 Delta { get; set; }

        public ChangePositionArgs(Vector2 delta)
        {
            this.Delta = delta;
        }
    }
}
