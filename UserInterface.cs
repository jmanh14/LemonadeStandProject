using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    static class UserInterface
    {
        public static void DisplayCurrentDay(int currentDay) 
        {
            Console.Write($"Day {currentDay}: ");
        }
        public static void DisplayWelcome(Player player)
        {
            Console.Clear();
            Console.WriteLine($"Welcome {player.name}, please enter your first recipe!");
        }
        public static int GetNumberOfItems(string itemsToGet)
        {
            bool userInputIsAnInteger = false;
            int quantityOfItem = -1;

            while (!userInputIsAnInteger || quantityOfItem < 0)
            {
                Console.WriteLine("How many " + itemsToGet + " would you like to buy?");
                Console.Write("Please enter a positive integer (or 0 to cancel)\n>> ");

                userInputIsAnInteger = Int32.TryParse(Console.ReadLine(), out quantityOfItem);
            }

            return quantityOfItem;
        }

        public static void GetWeatherConditions(Day day)
        {
            Console.WriteLine($"It is currently {day.weather.temperature} and {day.weather.condition} out.");
            
        }

        public static string GetUsersName()
        {
            Console.WriteLine("Hello and welcome to Lemonade Stand.");
            Console.Write("Please enter your name >> ");
            string name = Console.ReadLine();
            return name;
        }

        public static int BuySellInvRecipeOption()
        {
            try
            {
                Console.WriteLine("[1]Buy products for your lemonade.");
                Console.WriteLine("[2}Sell your lemonade.");
                Console.WriteLine("[3]Check your inventory.");
                Console.WriteLine("[4]Change recipe");
                Console.Write(">> ");
                int choice = int.Parse(Console.ReadLine());
                return choice;
            }
            catch (FormatException)
            {
                return BuySellInvRecipeOption();
            }
        }

        public static int ItemToBuyMenu(Store store)
        {
            Console.Clear();
            try
            {
                Console.WriteLine($"[1]Lemons(${store.pricePerLemon}) \n[2]Sugar cubes(${store.pricePerSugarCube}) \n[3]Ice cubes(${store.pricePerIceCube}) \n[4]Cups(${store.pricePerCup})");
                Console.Write(">> ");
                int choice = int.Parse(Console.ReadLine());
                return choice;
            }
            catch (FormatException)
            {
                return ItemToBuyMenu(store);
            }
        } 

        public static void DisplayWallet(Wallet wallet)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Current assets: ${wallet.Money}");
            Console.ResetColor();
        }
      
        public static void DisplayRecipe(Recipe recipe)
        {
            Console.Clear();
            
            Console.WriteLine($"RECIPE: ({recipe.name})");
            Console.WriteLine("------------------------");
            Console.WriteLine($"1. Lemons: {recipe.amountOfLemons}");
            Console.WriteLine($"2. Sugar Cubes: {recipe.amountOfSugarCubes}");
            Console.WriteLine($"3. Ice Cubes: {recipe.amountOfIceCubes}");
            Console.WriteLine($"4. Price per cup: ${recipe.pricePerCup}");
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
            Console.ResetColor();
        }

        public static string WouldYouLikeToContinue()
        {
            Console.Write("Press [n] to move to the next day\n>> ");
            string moveOn = Console.ReadLine();
            return moveOn;
        }

        public static int GetNumberOfDays()
        {
            Console.Clear();
            try
            {
                Console.WriteLine("How many days would you like to play for? ");
                Console.Write(">> ");
                int amountOfDays = int.Parse(Console.ReadLine());
                return amountOfDays;
            }
            catch (FormatException)
            {
                return GetNumberOfDays();  
            }
            
        }

        public static void DisplayCupsOfLemonade(Player player)
        {
            Console.WriteLine($"Plastic Cups Left: {player.inventory.cups.Count}");
        }


        public static void DisplayEndGameMessage(int currentDay, Player player)
        {
            Console.Clear();
            Console.WriteLine("End of the Game.");
            Console.WriteLine($"You made it to Day {currentDay} and ended with a total of ${player.wallet.Money}");
            Console.ReadLine();
            return;
        }

        public static void DisplayMoneyMessage(int currentDay)
        {
            Console.WriteLine($"You've run out of money on Day {currentDay}!");
            Console.ReadLine();
            return;
        }

        public static void DesplayCustomerCount(int buyerCounter, Day day)
        {
            Console.WriteLine($"{buyerCounter} out of {day.customers.Count} customers bought lemonade.");
        }

        public static void DisplayMoneyInvMessage(int currentDay)
        {
            Console.WriteLine($"You've run out of product and money on Day {currentDay}");
            Console.ReadLine();
        }
    }
}
