using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Pitcher
    {
        public int cupsLeftInPitcher;

        public Pitcher()
        {
            cupsLeftInPitcher = 0;
        }

        public void AddCups(Recipe recipe, Inventory inventory)
        {
           while (inventory.lemons.Count > 0 && inventory.sugarCubes.Count > 0 && inventory.iceCubes.Count > 0 && inventory.cups.Count > 0)
            {
                cupsLeftInPitcher++;
                inventory.lemons.Remove(inventory.lemons[0]);
                inventory.sugarCubes.Remove(inventory.sugarCubes[0]);
                inventory.iceCubes.Remove(inventory.iceCubes[0]);
                inventory.cups.Remove(inventory.cups[0]);
            }
        }
    }
}
