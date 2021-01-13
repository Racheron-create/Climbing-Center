using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Climbing
{
    class Route
    {
        public string Colour { get; set; } 
        public string Grade { get; set; }
        public int Number { get; set; }
        public Route(string colour, string grade, int number)
        {
            Number = number;
            Colour = colour;
            Grade = grade;
        }
    }
}
