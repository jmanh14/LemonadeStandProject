using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    static class UserInterface
    {
        public static int GetNumberOfItems(string itemsToGet)
        {
            bool userInputIsAnInteger = false;
            int quantityOfItem = -1;

            while (!userInputIsAnInteger || quantityOfItem < 0)
            {
                Console.WriteLine("How many " + itemsToGet + " would you like to buy?");
                Console.WriteLine("Please enter a positive integer (or 0 to cancel):");

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
            Console.WriteLine($"[1]Lemons(${store.pricePerLemon}) \n[2]Sugar cubes(${store.pricePerSugarCube}) \n[3]Ice cubes(${store.pricePerIceCube}) \n[4]Cups(${store.pricePerCup})");
            Console.Write(">> ");
            int choice = int.Parse(Console.ReadLine());
            return choice;
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
            Console.WriteLine("RECIPE");
            Console.WriteLine("-------------------");
            Console.WriteLine($"1. Lemons: {recipe.amountOfLemons}");
            Console.WriteLine($"2. Sugar Cubes: {recipe.amountOfSugarCubes}");
            Console.WriteLine($"3. Ice Cubes: {recipe.amountOfIceCubes}");
            Console.WriteLine($"4. Price per cup: ${recipe.pricePerCup}");
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }

        public static string WouldYouLikeToContinue()
        {
            Console.WriteLine("Press [y] to continue or [n] to move to the next day");
            string moveOn = Console.ReadLine();
            return moveOn;
        }

        public static int GetNumberOfDays()
        {
            Console.Clear();
            try
            {
                Console.WriteLine("How many days would you like to play for? ");
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
            Console.WriteLine($"Cups Left: {player.inventory.cups.Count}");
        }
    }
}
