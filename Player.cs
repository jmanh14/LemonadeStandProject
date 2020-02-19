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
        public Pitcher pitcher;

        // constructor (SPAWNER)
        public Player()
        {
            inventory = new Inventory();
            wallet = new Wallet();           
            recipe = new Recipe();
            pitcher = new Pitcher();
        }

        // member methods (CAN DO)
        public void CheckInventory(Inventory inventory)
        {
            Console.WriteLine($"1. Lemons: {inventory.lemons.Count}");
            Console.WriteLine($"2. Sugar Cubes: {inventory.sugarCubes.Count}");
            Console.WriteLine($"3. Ice Cubes: {inventory.iceCubes.Count}");
            Console.WriteLine($"4. Total cups of lemonade: { pitcher.cupsOfLemonade}");
            Console.WriteLine($"5. Total pitchers of lemonade: {pitcher.pitchersOfLemonade}");
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }
        public void BuyItems(Store store, Player player, int item)
        {
            if (item == 1)
            {
                store.SellLemons(this);
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
                item = UserInterface.ItemToBuyMenu(store);
                BuyItems(store, player, item);
                pitcher.AddCups(player);
            }
        }
        public void SellLemonade(Day day)
        {
            int buyerCounter = 0;

            for (int i = 0; i < day.customers.Count; i++)
            {
                if (pitcher.cupsOfLemonade > 0 && inventory.cups.Count > 0)
                {
                    try
                    {
                        if (day.customers[i].payPreference >= recipe.pricePerCup && day.customers[i].tastePreference == recipe.sweetness)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"{day.customers[i].fullName} bought a cup");
                            Console.WriteLine($" ({day.customers[i].tastePreference}!)");
                            pitcher.cupsOfLemonade--;
                            inventory.cups.Remove(inventory.cups[0]);
                            buyerCounter++;
                            wallet.GetMoneyForLemonade(recipe.pricePerCup);
                            Console.ResetColor();
                        }
                        else if (day.customers[i].payPreference >= recipe.pricePerCup && day.customers[i].tastePreference != recipe.sweetness)
                        {
                            Console.Write($"{day.customers[i].fullName} did not buy a cup");
                            Console.WriteLine($" (Not {day.customers[i].tastePreference}, too {recipe.sweetness})");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"{day.customers[i].fullName} did not buy a cup");
                            Console.WriteLine(" (Price too high)");
                            Console.ResetColor();
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
                    UserInterface.DesplayCustomerCount(buyerCounter, day);
                    return;
                }
            }

            UserInterface.DesplayCustomerCount(buyerCounter, day); 
            return;
        }
    }
}
