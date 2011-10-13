using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tower_of_Towerville.framework;

namespace Tower_of_Towerville.entities.components
{
    class Position : Component
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Position(float x, float y)
        {
            this.Name = "Position";
            this.X = x;
            this.Y = y;
        }
    }
}
