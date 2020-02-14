using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Customer
    {
        private List<string> names;
        public string name;
        public List<double> payPreferences;
        public double payPreference;
        Random random = new Random();
        public Customer()
        {
           
            names = new List<string>() { "Justin", "Eddie", "Matt", "Joey", "Tarik", "Braden", "Nick", "Osman", "Gavin", "Cody" };
            payPreferences = new List<double>() { .05, .1, .15, .2, .25, .3, .35, .4, .45, .5 };
            payPreference = payPreferences[random.Next(payPreferences.Count)];
            name = names[random.Next(names.Count)];
        }
    
       
    }
}
