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
            string[] grades = new string[] {"1", "3","3","2","4"};
            depot.NewCircuit("Red", grades);
            depot.DisplayCircuit("Red");

            Customer rachel = depot.CreateCustomer("Rachel", "Female", 2000, 05, 22);
            Customer jamie =  depot.CreateCustomer("Jamie", "Wright", 1964, 05, 11);
            List<Customer> customers = depot.Customers;
            rachel.SendRoute(depot, "Red", 1);
            rachel.SendRoute(depot, "Red", 3);
            rachel.SendRoute(depot, "Red", 5);

            Console.WriteLine("Rachel's average grade is " + rachel.AverageGrade());



            depot.RemoveCustomer(1);

            Console.WriteLine(depot.CustomerCount);

            Console.ReadLine();
        }
    }
}
