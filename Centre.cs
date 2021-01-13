using Climbing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Climbing
{
    class Center
    {
        //variables for object center
        public List<Climbing.Customer> Customers { get; set; }
        public Dictionary<string, List<Route>> Circuits { get; set; }
        public string Name { get; set; }
        public int CustomerCount { get; set; }
        //creating a center
        public Center(string name)
        {
            Name = name;
            CustomerCount = 0;
            Customers = new List<Climbing.Customer>();
            Circuits = new Dictionary<string, List<Route>>();
        }

        //creating a customer. Input validation needed
        public void CreateCustomer()
        {
            //add 1 to number of customers at the specific center
            CustomerCount++;
            //create the customer
            Customers.Add(new Customer(CustomerCount));
        }

        public void RemoveCustomer(int number)
        {
            int i = 0;
            int x = -1;
            //loop over each customer
            Customers.ForEach(delegate (Customer person) {
                if (person.Number == number)
                {
                    //save index we want to get rid of and drop count of customers at that center
                    x = i;
                    CustomerCount--;
                }
                else i++;
            });
            //remove customer if found
            if (x > -1) { Customers.RemoveAt(x); }
        }

        //create circuit and add it to dictionary of all circuits for center 
        public void NewCircuit()
        {
            Circuit circuit = new Circuit();
            string colour = circuit.Colour;
            List<Route> routes = circuit.Routes;
            Circuits.Add(colour, routes);
        }

        //display specific circuit in a center
        public void DisplayCircuit()
        {
            Console.Write("What circuit do you want to see? ");
            string colour = Console.ReadLine();
            if (Circuits.TryGetValue(colour, out List<Route> routes))
            {
                routes = Circuits[colour];
                int i = 1;
                routes.ForEach(delegate (Route route) {
                    Console.WriteLine("Route " + route.Number + " is grade " + route.Grade + ".");
                    i++;
                });
            }
            else
            {
                Console.WriteLine("That circuit doesn't exist");
            }
        }

        public void DeleteCircuit()
        {
            Console.Write("What colour do you want to delete? ");
            string colour = Console.ReadLine();

            Circuits.Remove(colour);
            Customers.ForEach(delegate (Customer customer)
            {
                customer.WipeAttempts(colour);
            });
        }
    }
}
