using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Player
    {
        // member variables (HAS A)
        public Inventory inventory;
        public Wallet wallet;
        public string name;
        public Recipe recipe;
        public Pitcher pitcher = new Pitcher();

        // constructor (SPAWNER)
        public Player()
        {
            inventory = new Inventory();
            wallet = new Wallet();
            
            recipe = new Recipe();
        }

        // member methods (CAN DO)
        public void CheckInventory(Inventory inventory)
        {
            Console.WriteLine($"Lemons: {inventory.lemons.Count}");
            Console.WriteLine($"Sugar Cubes: {inventory.sugarCubes.Count}");
            Console.WriteLine($"Ice Cubes: {inventory.iceCubes.Count}");
            Console.WriteLine($"Cups: {inventory.cups.Count}");
        }
    }
}
