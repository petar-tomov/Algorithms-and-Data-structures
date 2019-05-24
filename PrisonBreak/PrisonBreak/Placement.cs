using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonBreak
{
    class Placement
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Placement(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return $"{this.X} {this.Y}";
        }
    }
}
