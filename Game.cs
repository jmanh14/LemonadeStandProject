using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Game
    {

        private Player player;
        private List<Day> days;
        private int currentDay;
        private int menuOption;
        private int itemToBuy;
        private string wouldYouLikeToContinue = "Y";
        Store store = new Store();
        private Day day;
        public Random random = new Random();
        public void PlayGame()
        {
            player = new Player();
            day = new Day(random);
            player.name = UserInterface.GetUsersName();
            currentDay = 1;
            days = new List<Day>() { day };   
            Console.WriteLine($"Welcome {player.name}, please enter your first recipe!");
            player.recipe.CreateRecipe();
            UserInterface.DisplayRecipe(player.recipe);
           
            for (int i = 0; i <= 7; i++)
            {
                wouldYouLikeToContinue = "Y";
                while (wouldYouLikeToContinue == "Y" || wouldYouLikeToContinue == "y")
                {
                    Console.Write($"Day {currentDay}: ");
                    UserInterface.GetWeatherConditions(days[currentDay - 1]);
                    UserInterface.DisplayWallet(player.wallet);
                    menuOption = UserInterface.BuySellInvRecipeOption();
                    MenuSelection(menuOption);
                    wouldYouLikeToContinue = UserInterface.WouldYouLikeToContinue();
                }
                days.Add(new Day(random));
                currentDay++;
            }
            Console.WriteLine("End of the week.");
            Console.WriteLine($"You ended with a total of ${player.wallet.Money}");
            Console.ReadLine();

        }

        private void MenuSelection(int menuOption)
        {
            if (menuOption == 1)
            {
                itemToBuy = UserInterface.ItemToBuyMenu();
                BuyItems(itemToBuy);
                player.pitcher.AddCups(player.inventory);
            }
            else if (menuOption == 2)
            {
                SellLemonade();
            }
            else if (menuOption == 3)
            {
                player.CheckInventory(player.inventory);
            }
            else if (menuOption == 4)
            {

                player.recipe.CreateRecipe();
                UserInterface.DisplayRecipe(player.recipe);
            }
        }
        private void BuyItems(int item)
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
                itemToBuy = UserInterface.ItemToBuyMenu();
            }
        }

        public void SellLemonade()
        {

            for (int i = 0; i < player.pitcher.cupsLeftInPitcher; i++)
            {
                try
                {
                    if (day.customers[i].payPreference >= player.recipe.pricePerCup && day.customers[i].tastePreference == player.recipe.sweetness)
                    {
                        Console.Write($"{day.customers[i].fullName} bought a cup");
                        Console.WriteLine($" ({day.customers[i].tastePreference}!)");
                        player.pitcher.cupsLeftInPitcher--;
                        player.wallet.GetMoneyForLemonade(player.recipe.pricePerCup);
                    }
                    else if (day.customers[i].payPreference >= player.recipe.pricePerCup && day.customers[i].tastePreference != player.recipe.sweetness)
                    {
                        Console.Write($"{day.customers[i].fullName} did not buy a cup");
                        Console.WriteLine($" (Not {day.customers[i].tastePreference}, too {player.recipe.sweetness})");
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

