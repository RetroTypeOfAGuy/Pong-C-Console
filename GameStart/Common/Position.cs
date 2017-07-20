using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStart
{
    public class Position
    {
        public int X { get; set; }

        public int Y { get; set; }
        public Position(int y, int x)
        {
            this.Y = y;
            this.X = x;
        }
    }
}
