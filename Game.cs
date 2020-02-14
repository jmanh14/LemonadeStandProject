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
        private Day day = new Day();
        private int currentDay;
        private int menuOption;
        private int itemToBuy;
        private string wouldYouLikeToContinue ;
        Store store = new Store();
        Random random = new Random();
        public void PlayGame()
        {
            player = new Player();
            player.name = UserInterface.GetUsersName();
            currentDay = 1;
            days = new List<Day>() { new Day()};
            Console.WriteLine($"Welcome {player.name}, please enter your first recipe!");
            player.recipe.CreateRecipe();
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
                days.Add(new Day());
                currentDay++;
            }
            Console.ReadLine();
           
        }
        private void MenuSelection(int menuOption)
        {
            if (menuOption == 1)
            {
                itemToBuy = UserInterface.ItemToBuyMenu();
                Buy(itemToBuy);
                player.pitcher.AddCups(player.recipe, player.inventory);
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
        private void Buy(int item)
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
                if (day.customer.payPreference >= player.recipe.pricePerCup )
                {
                    Console.WriteLine($"{day.customer.name} bought a cup");
                    player.pitcher.cupsLeftInPitcher--;
                    day.customers.Add(new Customer()) ;
                    
                }
                else
                {
                    Console.WriteLine("Price too high");
                }
            }
        }
    }
}
