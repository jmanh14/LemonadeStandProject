using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Pitcher
    {
        public int pitchersOfLemonade;
        public int cupsOfLemonade;
        public int cupsPerPitcher = 25;
        public Pitcher()
        {
            pitchersOfLemonade = 0;
            cupsOfLemonade = 0;
        }

        public void AddCups(Player player)
        {
            while (player.inventory.lemons.Count > 0 && player.inventory.sugarCubes.Count > 0 && player.inventory.iceCubes.Count > 0 && player.inventory.cups.Count > 0)
            {
                try
                {
                    player.inventory.lemons.RemoveRange(0, player.recipe.amountOfLemons);
                    player.inventory.sugarCubes.RemoveRange(0, player.recipe.amountOfSugarCubes);
                    player.inventory.iceCubes.RemoveRange(0, player.recipe.amountOfIceCubes);
                    //player.inventory.cups.Remove(player.inventory.cups[0]);
                    pitchersOfLemonade++;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Out of Product!");
                    break;
                }
            }
            
            cupsOfLemonade = pitchersOfLemonade * cupsPerPitcher;
        }
    }
}
