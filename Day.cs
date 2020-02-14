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
        public Customer customer;
        Random rand = new Random();
        public Day()
        {
            
            weather = new Weather();
            customers = new List<Customer>() { new Customer()};
            customer = customers[rand.Next(customers.Count)];
        }
        
    }
}
