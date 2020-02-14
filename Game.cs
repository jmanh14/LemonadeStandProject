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
        Store store = new Store();
        public void PlayGame()
        {
            player = new Player();
            currentDay = 1;
            days = new List<Day>() { new Day()};
            for (int i = 0; i <= 7; i++) 
            {
                Console.Write($"Day {currentDay}: ");
                UserInterface.GetWeatherConditions(days[currentDay - 1]);
                UserInterface.DisplayWallet(player.wallet);
                menuOption = UserInterface.BuySellInvRecipeOption();
                if (menuOption == 1)
                {
                    itemToBuy = UserInterface.ItemToBuyMenu();
                    Buy(itemToBuy);
                }
                else if (menuOption == 2)
                {

                }
                else if (menuOption == 3)
                {

                }
                else if (menuOption == 4)
                {

                    Recipe recipe = new Recipe();
                    UserInterface.DisplayRecipe(recipe);
                }
                days.Add(new Day());
                currentDay++;
            }
            Console.ReadLine();
           
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
    }
}
