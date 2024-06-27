using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//MCPETRIE-ST10263164-PROG6221POEPART2
namespace PROG6221POEPART2
{
    internal class Ingredient
    {
        public string name { get; set; }
        public string foodGroup { get; set; }
        public string unit { get; set; }
        public double quantity { get; set; }
        public double calories { get; set; }

        public Ingredient(string name, string foodGroup, string unit, double quantity, double calories)
        {
            this.name = name;
            this.foodGroup = foodGroup;
            this.unit = unit;
            this.quantity = quantity;
            this.calories = calories;
        }

    }
}
