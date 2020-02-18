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
            Console.WriteLine($"Total cups of lemonade: { pitcher.cupsLeftInPitcher}");
        }
        public void BuyItems(Store store, Player player, int item)
        {
            if (item == 1)
            {
                store.SellLemons(player);
            }
            else if (item == 2)
            {
                store.SellSugarCubes(player);
            }
            else if (item == 3)
            {
                store.SellIceCubes(player);
            }
            else if (item == 4)
            {
                store.SellCups(player);
            }
            else
            {
                item = UserInterface.ItemToBuyMenu();
                BuyItems(store, player, item);
                pitcher.AddCups(player.inventory);
            }
        }
        public void SellLemonade(Day day)
        {

            for (int i = 0; i < pitcher.cupsLeftInPitcher; i++)
            {
                try
                {
                    if (day.customers[i].payPreference >= recipe.pricePerCup && day.customers[i].tastePreference == recipe.sweetness)
                    {
                        Console.Write($"{day.customers[i].fullName} bought a cup");
                        Console.WriteLine($" ({day.customers[i].tastePreference}!)");
                        pitcher.cupsLeftInPitcher--;
                        wallet.GetMoneyForLemonade(recipe.pricePerCup);
                    }
                    else if (day.customers[i].payPreference >= recipe.pricePerCup && day.customers[i].tastePreference != recipe.sweetness)
                    {
                        Console.Write($"{day.customers[i].fullName} did not buy a cup");
                        Console.WriteLine($" (Not {day.customers[i].tastePreference}, too {recipe.sweetness})");
                    }
                    else
                    {
                        Console.Write($"{day.customers[i].fullName} did not buy a cup");
                        Console.WriteLine(" (Price too high)");
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("No more customers!");
                }
            }
        }
    }
}
