using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//MCPETRIE-ST10263164-PROG6221POEPART2
namespace PROG6221POEPART2
{
    delegate void RecipeEventHandler(string message); //delegate for event

    internal class Recipe
    {
        public string name { get; set; }
        public List<Ingredient> Ingredients { get; set; } //lists of ingredient class instances
        public List<Instruction> Instructions { get; set; } //lists of instruction class instances
        public double scale { get; set; } //scale factor for recipe so it can revert back to its original scale (1)

        public Recipe(string name, List<Ingredient> ingredients, List<Instruction> instructions, double scale)
        {
            this.name = name;
            this.Ingredients = ingredients;
            this.Instructions = instructions;
            this.scale = scale;
        }

        //-----------------DELEGATE-----------------

        public event RecipeEventHandler ExcededCalories;

        public void TotalCalories()
        {
            double totalCalories = 0;

            foreach (Ingredient ingredient in Ingredients)
            {
                totalCalories += ingredient.calories;
            }

            if (totalCalories > 300)
            {
                ExcededCalories?.Invoke("---------WARNING----------\nRECIPE EXCEDES 300 CALORIES");
            }
        }


    }
}
