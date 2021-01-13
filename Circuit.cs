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
        public List<Climbing.Route> Routes { get; set; }
        public Circuit()
        {
            Routes = new List<Climbing.Route>();
            Console.Write("What colour is the circuit? ");
            Colour = Console.ReadLine();
            Console.Write("How many routes in the circuit? ");
            string s_num = Console.ReadLine();
            int i_num = int.Parse(s_num);
            for (int i = 0; i < i_num; i++)
            {
                int x = i + 1;
                Console.Write("What grade is route " + x + "? ");
                string grade = Console.ReadLine();
                Routes.Add(new Route(Colour, grade, x));
            }
        }
    }
}
