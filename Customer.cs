using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Customer
    {
        private List<string> firstNames;
        private List<string> lastNames;
        public string firstName;
        public string lastName;
        public string fullName;
        public List<double> payPreferences;
        public double payPreference;
        public List<string> tastePreferences;
        public string tastePreference;
        public Customer(Random rng)
        {
            firstNames = new List<string>() { "Justin", "Eddie", "Matt", "Joey", "Tarik", "Braden", "Nick", "Osman", "Gavin", "Cody", "James", "John", "Paula", "Jackson", "Brooke", "Jamie", "Jared", "Brad", "Tom", "Linda", "Doug"};
            lastNames = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            payPreferences = new List<double>() { .05, .1, .15, .2, .25, .3, .35, .4, .45, .5 , .5,.55, .6, .65, .7, .75, .8, .85, .9, .95, 1};
            tastePreferences = new List<string>() { "Sweet", "Sour", "Balanced" , "Bland", "Watery"};
            payPreference = payPreferences[rng.Next(payPreferences.Count)];
            firstName = firstNames[rng.Next(firstNames.Count)];
            lastName = lastNames[rng.Next(lastNames.Count)];
            fullName = firstName + " " + lastName;
            tastePreference = tastePreferences[rng.Next(tastePreferences.Count)];
        }

     




    }
}
