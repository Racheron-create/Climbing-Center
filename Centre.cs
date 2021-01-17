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
        public List<Customer> Customers { get; set; }
        public Dictionary<string, List<Route>> Circuits { get; set; }
        public string Name { get; set; }
        public int CustomerCount { get; set; }
        //creating a center
        public Center(string name)
        {
            Name = name;
            CustomerCount = 0;
            Customers = new List<Customer>();
            Circuits = new Dictionary<string, List<Route>>();
        }

        //creating a customer. Input validation needed
        public Customer CreateCustomer(string name, string gender, int year, int month, int day)
        {
            //add 1 to number of customers at the specific center
            CustomerCount++;
            //create the customer
            Customer newCustomer = new Customer(CustomerCount, name, gender, year, month, day);
            Customers.Add(newCustomer);
            return newCustomer;
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

        public void CustomerLogin(int number)
        {
            //loop over each customer
            Customers.ForEach(delegate (Customer person) {
                if (person.Number == number)
                {
                    person.SessionNumber++;
                }
            });
        }

        //create circuit and add it to dictionary of all circuits for center 
        public void NewCircuit(string colour, string[] grades)
        {
            Circuit circuit = new Circuit(colour, grades);
            List<Route> routes = circuit.Routes;
            Circuits.Add(colour, routes);
        }

        //display specific circuit in a center
        public void DisplayCircuit(string colour)
        {
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

        public void DeleteCircuit(string colour)
        {
            Circuits.Remove(colour);
            Customers.ForEach(delegate (Customer customer)
            {
                customer.WipeAttempts(colour);
            });
        }
    }
}
