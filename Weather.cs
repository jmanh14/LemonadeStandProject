using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Weather
    {
        //Member variables (HAS A)
        public string condition;
        public int temperature;
        private List<string> weatherConditons;
        
        //Constructor
        public Weather(Random rng)
        {         
            weatherConditons = new List<string>() { "Sunny", "Rainy", "Foggy", "Cloudy" };
            condition = weatherConditons.ElementAt(rng.Next(0, weatherConditons.Count));
            temperature = Gettemperature(rng);
        }
        //Member methods (CAN DO)
        public int Gettemperature(Random rng)
        {
            if (condition == "Sunny")
            {
                temperature = rng.Next(70, 100);
            }
            else if (condition == "Rainy")
            {
                temperature = rng.Next(30, 50);
            }
            else if (condition == "Foggy")
            {
                temperature = rng.Next(60, 70);
            }
            else
            {
                temperature = rng.Next(50, 70);
            }
            return temperature;

        }

        
    }
}
