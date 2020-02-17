using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Recipe
    {
        public int amountOfLemons;
        public int amountOfSugarCubes;
        public int amountOfIceCubes;
        public double pricePerCup;
        public string sweetness;

        public Recipe()
        {
        }

        public void CreateRecipe()
        {
            Console.Write("Lemons: ");
            int lemons = int.Parse(Console.ReadLine());
            Console.Write("Sugar Cubes: ");
            int sugarCubes = int.Parse(Console.ReadLine());
            Console.Write("Ice Cubes: ");
            int iceCubes = int.Parse(Console.ReadLine());
            Console.Write("Price per cup: ");
            double cupPrice = double.Parse(Console.ReadLine());
            amountOfLemons = lemons;
            amountOfSugarCubes = sugarCubes;
            amountOfIceCubes = iceCubes;
            pricePerCup = cupPrice;
        }      
    }
}
