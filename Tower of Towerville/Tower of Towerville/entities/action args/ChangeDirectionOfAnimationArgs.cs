using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tower_of_Towerville.framework;

namespace Tower_of_Towerville.entities.action_args
{
    class ChangeDirectionOfAnimationArgs : ActionArgs
    {
        public string Direction { get; set; }

        public ChangeDirectionOfAnimationArgs(string direction)
        {
            this.Direction = direction;
        }
    }
}
