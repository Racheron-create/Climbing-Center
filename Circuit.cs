using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Climbing
{
    class Circuit
    {
        //creates one circuit
        public string Colour { get; set; }
        public List<Route> Routes { get; set; }
        public Circuit(string colour, string[] inGrade)
        {
            Routes = new List<Route>();
            int numOfRoutes = inGrade.Length;
            for (int i = 0; i < numOfRoutes; i++)
            {
                Routes.Add(new Route(Colour, inGrade[i], i+1));
            }
        }
    }
}
