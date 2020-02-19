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
        public string name;

        public Recipe()
        {
            
        }

        public void CreateRecipe()
        {
            try
            {
                Console.Write("1. Lemons: ");
                int lemons = int.Parse(Console.ReadLine());
                Console.Write("2. Sugar Cubes: ");
                int sugarCubes = int.Parse(Console.ReadLine());
                Console.Write("3. Ice Cubes: ");
                int iceCubes = int.Parse(Console.ReadLine());
                Console.Write("4. Price per cup: ");
                double cupPrice = double.Parse(Console.ReadLine());
                amountOfLemons = lemons;
                amountOfSugarCubes = sugarCubes;
                amountOfIceCubes = iceCubes;
                pricePerCup = cupPrice;
                DetermineSweetness(amountOfLemons, amountOfSugarCubes, amountOfIceCubes);
            }
            catch (FormatException)
            {
                Console.Clear();
                CreateRecipe();
            }
        }
        public void DetermineSweetness(int lemons, int sugarCubes, int iceCubes)
        {
            if (lemons >= 5 && sugarCubes < 5 && iceCubes >= 1)
            {
                sweetness = "Sour";
                name = "The Sour Lemon";
            }
            else if (lemons < 5 && sugarCubes >= 5 && iceCubes >= 1)
            {
                sweetness = "Sweet";
                name = "The Sweet Sally";
            }
            else if (iceCubes >= 5)
            {
                sweetness = "Watery";
                name = "The Sno-Cone";
            }
            else if (lemons == sugarCubes && iceCubes < 5)
            {
                sweetness = "Balanced";
                name = "The Standard";
            }
            else 
            {
                sweetness = "Bland";
                name = "The Eh";
            }
        }
    }
}
