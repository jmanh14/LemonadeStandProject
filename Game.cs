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
        private Store store;
        public Random random;
        private string wouldYouLikeToContinue = "Y";
        public Game()
        {
            store = new Store();
            player = new Player();
            random = new Random();
        }
        public void PlayGame()
        {
            int currentDay = 1;
            int menuOption;
            int amountOfDays;
            
            player.name = UserInterface.GetUsersName();
            amountOfDays = UserInterface.GetNumberOfDays();
            days = new List<Day>() { new Day(random) };
            UserInterface.DisplayWelcome(player);
            player.recipe.CreateRecipe();
            UserInterface.DisplayRecipe(player.recipe);

            for (int i = 0; i < amountOfDays; i++)
            {
                wouldYouLikeToContinue = "Y";
                player.pitcher.pitchersOfLemonade /= 2;
                player.pitcher.cupsOfLemonade = player.pitcher.pitchersOfLemonade * player.pitcher.cupsPerPitcher;
                while (wouldYouLikeToContinue.ToLower() == "y")
                {
                    if (player.wallet.Money > 0 || (player.inventory.lemons.Count > 0 && player.inventory.iceCubes.Count > 0 && player.inventory.sugarCubes.Count > 0 && player.inventory.cups.Count > 0)) //If player money > 0 OR the item in inventory > 0
                    {
                        Console.Clear();
                        UserInterface.DisplayCurrentDay(currentDay);
                        UserInterface.GetWeatherConditions(days[currentDay - 1]);
                        UserInterface.DisplayWallet(player.wallet);
                        UserInterface.DisplayCupsOfLemonade(player);
                        menuOption = UserInterface.BuySellInvRecipeOption();
                        MenuSelection(menuOption, currentDay);
                    }
                    else if (player.wallet.Money <= 0 && (player.inventory.lemons.Count == 0 || player.inventory.iceCubes.Count == 0 || player.inventory.sugarCubes.Count == 0 || player.inventory.cups.Count == 0))// if player money <= 0 AND and a item in inventory = 0
                    {
                        UserInterface.DisplayMoneyMessage(currentDay);
                        return;
                    }
                    else if (player.wallet.Money <= 0 && (player.inventory.lemons.Count == 0 && player.inventory.iceCubes.Count == 0 && player.inventory.sugarCubes.Count == 0 && player.inventory.cups.Count == 0)) // If money <Ju= 0 AND all items in inventory = 0
                    {
                        UserInterface.DisplayMoneyInvMessage(currentDay);
                    }
                }
                    days.Add(new Day(random));
                    currentDay++;
               
            }
           UserInterface.DisplayEndGameMessage(currentDay, player);

        }

        private void MenuSelection(int menuOption, int currentDay)
        {
            int itemToBuy;
            if (menuOption == 1)
            {
                itemToBuy = UserInterface.ItemToBuyMenu(store);
                player.BuyItems(store,itemToBuy);
                
            }
            else if (menuOption == 2)
            {
                player.pitcher.AddCups(player);
                player.SellLemonade(days[currentDay -1]);
                wouldYouLikeToContinue = UserInterface.WouldYouLikeToContinue();
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
            else
            {
                Console.WriteLine("Invalid input...");
                Console.ReadLine();
                menuOption = UserInterface.BuySellInvRecipeOption();
            }
        }
       

        
    }
}

