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
        Random random = new Random();
        //Constructor
        public Weather()
        {
            weatherConditons = new List<string>() { "Sunny", "Rainy", "Foggy", "Cloudy" };
            condition = weatherConditons.ElementAt(random.Next(0, 4));
            temperature = Gettemperature();
        }
        //Member methods (CAN DO)
        public int Gettemperature()
        {
            if (condition == "Sunny")
            {
                temperature = random.Next(70, 100);
            }
            else if (condition == "Rainy")
            {
                temperature = random.Next(50, 60);
            }
            else if (condition == "Foggy")
            {
                temperature = random.Next(60, 70);
            }
            else
            {
                temperature = random.Next(50, 70);
            }
            return temperature;

        }
    }
}
