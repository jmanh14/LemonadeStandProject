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
            Console.WriteLine($"1. Lemons: {inventory.lemons.Count}");
            Console.WriteLine($"2. Sugar Cubes: {inventory.sugarCubes.Count}");
            Console.WriteLine($"3. Ice Cubes: {inventory.iceCubes.Count}");
            Console.WriteLine($"4. Cups: {inventory.cups.Count}");
            Console.WriteLine($"5. Total cups of lemonade: { pitcher.cupsLeftInPitcher}");
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
            int buyerCounter = 0;

            for (int i = 0; i < day.customers.Count; i++)
            {
                if (pitcher.cupsLeftInPitcher > 0)
                {
                    try
                    {
                        if (day.customers[i].payPreference >= recipe.pricePerCup && day.customers[i].tastePreference == recipe.sweetness)
                        {
                            Console.Write($"{day.customers[i].fullName} bought a cup");
                            Console.WriteLine($" ({day.customers[i].tastePreference}!)");
                            pitcher.cupsLeftInPitcher--;
                            buyerCounter++;
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
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("No lemonade left to sell!");
                    Console.WriteLine($"{buyerCounter} out of {day.customers.Count} customers bought lemonade.");
                    return;
                }
            }

            Console.WriteLine($"{buyerCounter} out of {day.customers.Count} customers bought lemonade.");
        }
    }
}
