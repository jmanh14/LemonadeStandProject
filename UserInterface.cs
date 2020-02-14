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
            Console.WriteLine("[1]Buy products for your lemonade.");
            Console.WriteLine("[2}Sell your lemonade.");
            Console.WriteLine("[3]Check your inventory.");
            Console.WriteLine("[4]Change recipe");
            Console.Write(">> ");
            int choice = int.Parse(Console.ReadLine());
            return choice;
        }

        public static int ItemToBuyMenu()
        {
            Console.WriteLine("[1]Lemons [2]Sugar cubes [3]Ice cubes [4]cups");
            Console.Write(">> ");
            int choice = int.Parse(Console.ReadLine());
            return choice;
        } 

        public static void DisplayWallet(Wallet wallet)
        {
            Console.WriteLine($"Current assets: ${wallet.Money}");
        }
      
        public static void DisplayRecipe(Recipe recipe)
        {
            Console.WriteLine($"1. Lemons: {recipe.amountOfLemons}");
            Console.WriteLine($"2. Sugar Cubes: {recipe.amountOfSugarCubes}");
            Console.WriteLine($"3. Ice Cubes: {recipe.amountOfIceCubes}");
            Console.WriteLine($"4. Price per cup: ${recipe.pricePerCup}");
        }
    }
}
