using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Climbing
{

    class Customer
    {
        //creating a customer object
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get; set; }
        public int Number { get; set; }
        public int Sends { get; set; }
        public int Attempts { get; set; }
        public Dictionary<string, List<string>> MySends { get; set; }
        public Dictionary<string, List<Route>> MyAttempts { get; set; }
        public Customer(int number)
        {
            //name and gender, gender to be enum?
            Console.Write("Customer Name: ");
            string name = Console.ReadLine();
            Console.Write("Customer Gender: ");
            string gender = Console.ReadLine();
            //birthday
            Console.Write("Year of birth: ");
            string y = Console.ReadLine();
            int year = Int16.Parse(y);
            Console.Write("Month of birth: ");
            string m = Console.ReadLine();
            int month = Int16.Parse(m);
            Console.Write("Day of birth: ");
            string d = Console.ReadLine();
            int day = Int16.Parse(d);

            Name = name;
            Birthday = new DateTime(year, month, day);
            Age = DateTime.Today.Year - Birthday.Year;
            Number = number;
            Gender = gender;
            Sends = 0;
            Attempts = 0;
            MySends = new Dictionary<string, List<string>>();
            MyAttempts = new Dictionary<string, List<Route>>();
        }

        //customer sends route, stored as string List<string>
        public void SendRoute(Center center, string colour, int number)
        {
            Dictionary<string, List<Route>> circuits = center.Circuits;
            List<Route> routes = circuits[colour];
            Route route = routes[number];
            string difficulty = route.Grade;
            if (MySends.TryGetValue(colour, out _))
            {
                List<string> myDifficulties = MySends[colour];
                myDifficulties.Add(difficulty);
                MySends[colour] = myDifficulties;
            }
            else
            {
                List<string> newDifficulties = new List<string>
                {
                    difficulty
                };
                MySends.Add(colour, newDifficulties);
            }
            Sends++;
            Attempts++;
        }

        //customer tries route, stored as string List<Route>
        public void TryRoute(Center center, string colour, int number, int tries)
        {
            {
                Dictionary<string, List<Route>> circuits = center.Circuits;
                List<Route> routes = circuits[colour];
                Route route = routes[number];
                if (MyAttempts.TryGetValue(colour, out _))
                {
                    List<Route> myDifficulties = MyAttempts[colour];
                    myDifficulties.Add(route);
                    MyAttempts[colour] = myDifficulties;
                }
                else
                {
                    List<Route> newDifficulties = new List<Route>
                {
                    route
                };
                    MyAttempts.Add(colour, newDifficulties);
                }
            }
            Attempts += tries;
        }

        public void WipeAttempts(string colour)
        {
            MyAttempts.Remove(colour);
        }
    }
}
