using PROG6221POEPART2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace PROG6221POE3.Methods
{
    internal class Method
    {
        List<Recipe> recipes = new List<Recipe>();
        List<Ingredient> ingredients = new List<Ingredient>();
        List<Instruction> instructions = new List<Instruction>();

        public void AddIngredient(string ingName, double ingQuantity, string ingUnit, string ingFoodGroup, double ingNumCalories) 
        {
            ingredients.Add(new Ingredient(ingName, ingFoodGroup, ingUnit, ingQuantity, ingNumCalories));
        }

        public void AddStep(int countStep, string text) 
        {
            instructions.Add(new Instruction(countStep, text));
        }

        public void AddRecipe(string recipeName) 
        {
            recipes.Add(new Recipe(recipeName, ingredients, instructions, 1));
            MessageBox.Show("Recipe added successfully!");
        }

        public double CalculateTotalCalories(string recipeName) //method to calculate total calories in a recipe
        {
            double totalCalories = 0;

            foreach (Recipe recipe in recipes)
            {
                if (recipe.name == recipeName)
                {
                    foreach (Ingredient ingredient in recipe.Ingredients)
                    {
                        totalCalories += ingredient.calories;
                    }
                }
            }

            return totalCalories;
        }

        public string DisplayAllRecipes() 
        {
            string ToString = "";

            recipes = recipes.OrderBy(r => r.name).ToList();

            foreach (Recipe recipe in recipes)
            {
                ToString += "\t\tRecipe Name:" + recipe.name;
                ToString += "\n\t\tIngredients:";

                foreach (Ingredient ingredient in recipe.Ingredients)
                {
                    ToString += "\n1)\t\t " + ingredient.name + "\nFood Group:\t\t" + ingredient.foodGroup + "\nQuantity:\t\t" + ingredient.quantity + " " + ingredient.unit + "\nCalories:\t\t" + ingredient.calories;
                }

                ToString += "\n\nTotal Calories: " + CalculateTotalCalories(recipe.name); //adds total calories

                foreach (Instruction instruction in recipe.Instructions)
                {
                    ToString += "\nSTEP " + instruction.stepNumber + ":\n" + instruction.step;
                }
            }
            return ToString;
        }

        public string DisplayRecipe(string recipeName)
        {
            string ToString = "";

            recipes = recipes.OrderBy(r => r.name).ToList();

            foreach (Recipe recipe in recipes)
            {
                ToString += "\t\tRecipe Name:" + recipe.name;
                ToString += "\n\t\tIngredients:";

                if (recipeName == recipe.name)
                {
                    foreach (Ingredient ingredient in recipe.Ingredients)
                    {
                        ToString += "\n1)\t\t " + ingredient.name + "\nFood Group:\t\t" + ingredient.foodGroup + "\nQuantity:\t\t" + ingredient.quantity + " " + ingredient.unit + "\nCalories:\t\t" + ingredient.calories;
                    }

                    ToString += "\n\nTotal Calories: " + CalculateTotalCalories(recipe.name); //adds total calories

                    foreach (Instruction instruction in recipe.Instructions)
                    {
                        ToString += "\nSTEP " + instruction.stepNumber + ":\n" + instruction.step;
                    }
                }
            }
            return ToString;
        }

        public string DisplayRecipeIngredient(string ingName) //diplays all recipes with selected ingedient
        {
            string ToString = "";
            int count = 0; 

            recipes = recipes.OrderBy(r => r.name).ToList();

            foreach (Recipe recipe in recipes)
            {
                foreach (Ingredient ingredient in recipe.Ingredients)
                {
                    if (ingName == ingredient.name) 
                    {
                        count++;
                        ToString += count + ") " + recipe.name + "\n";
                    }
                }
            }
            return ToString;
        }

        public string DisplayRecipeGroup(string foodGroup) //diplays all recipes with selected food group
        {
            string ToString = "";
            int count = 0;

            recipes = recipes.OrderBy(r => r.name).ToList();

            foreach (Recipe recipe in recipes)
            {
                foreach (Ingredient ingredient in recipe.Ingredients)
                {
                    if (foodGroup == ingredient.foodGroup)
                    {
                        count++;
                        ToString += count + ") " + recipe.name + "\n";
                    }
                }
            }
            return ToString;
        }

        public string DisplayRecipeMaxCalories(double numCalories) //diplays all recipes with total calories under selected amount
        {
            string ToString = "";
            int count = 0;
            double totalCalories = 0;

            recipes = recipes.OrderBy(r => r.name).ToList();

            foreach (Recipe recipe in recipes)
            {
                totalCalories = CalculateTotalCalories(recipe.name);
                if (totalCalories <= numCalories) 
                {
                    count++;
                    ToString += count + ") " + recipe.name + "Calories: " + totalCalories + "\n";
                }
            }
            return ToString;
        }
        
    }
}
