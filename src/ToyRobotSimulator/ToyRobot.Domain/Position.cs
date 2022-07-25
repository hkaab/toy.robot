using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot.Domain
{
    public class Position
    {
        public ushort X { get; set; }
        public ushort Y { get; set; }
        public Position(ushort x, ushort y)
        {
            X = x;
            Y = y;  
        }
        public override string ToString()
        {
            return $"{X},{Y}";
        }
    }
}
