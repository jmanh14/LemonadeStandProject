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
        
        public void DetermineAmountOfCustomers(Weather weather ,Random randomNum)
        {
            double amountOfCustomers = 0;
            double maxAmountOfCustomers = 50;
            if (weather.temperature >= 70)
            {
                amountOfCustomers = maxAmountOfCustomers;
            }
            else if (weather.temperature < 70 && weather.temperature >= 60)
            {
                amountOfCustomers = Math.Round(maxAmountOfCustomers * .66);
            }
            else if (weather.temperature < 60 && weather.temperature >= 50)
            {
                amountOfCustomers = Math.Round(maxAmountOfCustomers * .5);
            }
            else
            {
                amountOfCustomers = Math.Round(maxAmountOfCustomers * .2);
            }
            for (int i = 0; i < amountOfCustomers; i++)
            {
                customers.Add(new Customer(randomNum));
            }
        }

    }
}
