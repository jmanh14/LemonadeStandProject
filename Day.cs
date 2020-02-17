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
            weather = new Weather(rng);
            customers = new List<Customer>() { };
            DetermineAmountOfCustomers(weather, rng);
        }
        public void DetermineAmountOfCustomers(Weather weathern ,Random randomNum)
        {
            int amountOfCustomers = 0;
            if (weather.temperature >= 70)
            {
                amountOfCustomers = 10;
            }
            else if (weather.temperature < 70 && weather.temperature >= 60)
            {
                amountOfCustomers = 8;
            }
            else if (weather.temperature < 60 && weather.temperature >= 50)
            {
                amountOfCustomers = 6;
            }
            else
            {
                amountOfCustomers = 3;
            }
            for (int i = 0; i <= amountOfCustomers; i++)
            {
                customers.Add(new Customer(randomNum));
            }
        }

    }
}
