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
        

        public Customer()
        {
            Random random = new Random();
            names = new List<string>() { "Justin", "Eddie", "Matt", "Joey", "Tarik", "Braden", "Nick", "Osman", "Gavin", "Cody" };
            name = names[random.Next(names.Count)];
        }

        public string GetCustomer()
        {
            return name;
        }
    }
}
