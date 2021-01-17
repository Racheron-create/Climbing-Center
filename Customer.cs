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
        public int SessionNumber { get; set; }
        public int Sends { get; set; }
        public string HighestGrade { get; set; }
        public string Average { get; set; }
        public int Attempts { get; set; }
        public Dictionary<string, List<string>> MySends { get; set; }
        public Dictionary<string, List<Route>> MyAttempts { get; set; }
        public Customer(int number, string name, string gender, int year, int month, int day)
        {
            Name = name;
            Birthday = new DateTime(year, month, day);
            Age = DateTime.Today.Year - Birthday.Year;
            Number = number;
            Gender = gender;
            Sends = 0;
            Attempts = 0;
            MySends = new Dictionary<string, List<string>>();
            MyAttempts = new Dictionary<string, List<Route>>();
            SessionNumber = 0;
            Average = "N/A";
            HighestGrade = "N/A";
        }

        public void AverageGrade()
        {
            Dictionary<string, List<string>> customerSends = MySends;
            double count = 0;
            double total = 0;
            foreach (var sends in customerSends)
            {
                foreach(string grade in sends.Value)
                {
                    total += Int32.Parse(grade);
                    count++;
                }
            }

            double av = total / count;
            double decpart = av - Math.Truncate(av);
            int intpart = (int)Math.Truncate(av);

            if (decpart < 0.3)
            {
                Average = ("V" + intpart);
            }
            else if(0.3<=decpart && decpart<=0.7)
            {
                Average = ("V" + intpart + "+");
            }
            else
            {
                Average = ("V" + intpart++);
            }
        }

        public void MaxGrade()
        {
            Dictionary<string, List<string>> customerSends = MySends;
            int max = 0;
            foreach (var sends in customerSends)
            {
                foreach (string grade in sends.Value)
                {
                    int intgrad = Int32.Parse(grade);
                    if (intgrad > max)
                    {
                        max = intgrad;
                    }
                }
            }
            HighestGrade = ("Your highest grade is " + max);
        }



        //customer sends route, stored as string List<string>
        public void SendRoute(Center center, string colour, int number)
        {
            Dictionary<string, List<Route>> circuits = center.Circuits;
            List<Route> routes = circuits[colour];
            number--;
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
            MaxGrade();
            AverageGrade();
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
