﻿using System;
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
        private int amountOfDays;
        private string wouldYouLikeToContinue = "Y";
        Store store = new Store();
        public Random random = new Random();
        private Day day; 
        public void PlayGame()
        {
            player = new Player();
            day = new Day(random);
            player.name = UserInterface.GetUsersName();
            amountOfDays = UserInterface.GetNumberOfDays();
            currentDay = 1;
            days = new List<Day>() { day };
            Console.Clear();
            Console.WriteLine($"Welcome {player.name}, please enter your first recipe!");
            player.recipe.CreateRecipe();
            UserInterface.DisplayRecipe(player.recipe);

            for (int i = 0; i < amountOfDays; i++)
            {
                wouldYouLikeToContinue = "Y";
                player.pitcher.cupsOfLemonade = player.pitcher.pitchersOfLemonade * player.pitcher.cupsPerPitcher;
                player.pitcher.pitchersOfLemonade /= 2;
                while (wouldYouLikeToContinue == "Y" || wouldYouLikeToContinue == "y")
                {
                    if (player.wallet.Money > 0)
                    {
                        Console.Clear();
                        Console.Write($"Day {currentDay}: ");
                        UserInterface.GetWeatherConditions(days[currentDay - 1]);
                        UserInterface.DisplayWallet(player.wallet);
                        UserInterface.DisplayCupsOfLemonade(player);
                        menuOption = UserInterface.BuySellInvRecipeOption();
                        MenuSelection(menuOption);
                        wouldYouLikeToContinue = UserInterface.WouldYouLikeToContinue();
                    }
                    else
                    {
                        Console.WriteLine("You've run out of money!");
                        return;
                    }
                }
                    days.Add(new Day(random));
                    currentDay++;
               
            }
            Console.WriteLine("End of the Game.");
            Console.WriteLine($"You ended with a total of ${player.wallet.Money}");
            Console.ReadLine();

        }

        private void MenuSelection(int menuOption)
        {
            if (menuOption == 1)
            {
                itemToBuy = UserInterface.ItemToBuyMenu(store);
                player.BuyItems(store,player,itemToBuy);
                player.pitcher.AddCups(player);
            }
            else if (menuOption == 2)
            {
                player.SellLemonade(days[currentDay -1]);
                return;
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
       

        
    }
}

