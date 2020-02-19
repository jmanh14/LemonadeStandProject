using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Customer
    {
        //Open-Closed Principle
        //This class is closed to modification because there isnt anything else a customer needs
        //You dont need to add more code to this class to make the project work
        //This class is open to extention because you can add more names, pay preferences and tastes to the lists
        //You can add more names, preferences and the program will stil work
        private List<string> firstNames;
        private List<string> lastNames;
        private string firstName;
        private string lastName;
        public string fullName;
        private List<double> payPreferences;
        public double payPreference;
        private List<string> tastePreferences;
        public string tastePreference;
        public Customer(Random rng)
        {
            firstNames = new List<string>() { "Justin", "Eddie", "Matt", "Joey", "Tarik", "Braden", "Nick", "Osman", "Gavin", "Cody", "James", "John", "Paula", "Jackson", "Brooke", "Jamie", "Jared", "Brad", "Tom", "Linda", "Doug"};
            lastNames = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            payPreferences = new List<double>() { .25, .3, .35, .4, .45, .5 , .5,.55, .6, .65, .7, .75, .8, .85, .9, .95, 1 , 1.25, 1.5, 1.75, 2};
            tastePreferences = new List<string>() { "Sweet", "Sour", "Balanced" , "Bland", "Watery"};
            payPreference = payPreferences[rng.Next(payPreferences.Count)];
            firstName = firstNames[rng.Next(firstNames.Count)];
            lastName = lastNames[rng.Next(lastNames.Count)];
            fullName = firstName + " " + lastName;
            tastePreference = tastePreferences[rng.Next(tastePreferences.Count)];
        }

     




    }
}
