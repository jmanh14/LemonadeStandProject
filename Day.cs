using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Day
    {
        public Weather weather;
        public List<Customer> customers;
        public Day(Random rng)
        {
            weather = new Weather();
            customers = new List<Customer>() { new Customer(rng), new Customer(rng), new Customer(rng), new Customer(rng), new Customer(rng) };

        }
        
    }
}
