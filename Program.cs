using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Climbing
{
    class Program
    {
        static void Main(string[] args)
        {
            Center depot = new Center("Depot");
            depot.NewCircuit();
            depot.DisplayCircuit();

            Center foundry = new Center("Foundry");
            foundry.NewCircuit();
            foundry.DisplayCircuit();

            depot.CreateCustomer();
            depot.CreateCustomer();
            depot.RemoveCustomer(1);

            Console.WriteLine(depot.CustomerCount);
            foundry.CreateCustomer();
            Console.WriteLine(foundry.CustomerCount);

            Console.ReadLine();
        }
    }
}
