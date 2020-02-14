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
        public Customer(Random rng)
        {
            names = new List<string>() { "Justin", "Eddie", "Matt", "Joey", "Tarik", "Braden", "Nick", "Osman", "Gavin", "Cody" };
            payPreferences = new List<double>() { .05, .1, .15, .2, .25, .3, .35, .4, .45, .5 , .55, .6, .65, .7, .75, .8, .85, .9, .95, 1};
            payPreference = payPreferences[rng.Next(payPreferences.Count)];
            name = names[rng.Next(names.Count)];
        }


    
       
    }
}
