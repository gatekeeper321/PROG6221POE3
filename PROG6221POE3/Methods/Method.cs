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

        public Method()
        {
            AddIngredient("Pasta", 4, "cup", "Carbohydrates", 300);
            AddIngredient("Tomato Sauce", 3, "cup", "Vegetables", 100);
            AddIngredient("Ground Beef", 5, "cup", "Proteins", 400);
            AddIngredient("Onion", 0.1, "whole", "Vegetables", 50);
            AddIngredient("Garlic", 2, "teaspoon", "Vegetables", 10);

            AddStep(1, "Boil water in a large pot.");
            AddStep(2, "Cook the pasta according to the package instructions.");
            AddStep(3, "In a separate pan, cook the ground beef, onion, and garlic until browned.");
            AddStep(4, "Add the tomato sauce to the pan and simmer for 10 minutes.");
            AddStep(5, "Serve the cooked pasta with the meat sauce on top.");

            recipes.Add(new Recipe("Spaghetti", ingredients, instructions, 1));

            ingredients.Clear();
            instructions.Clear();

            AddIngredient("Pizza Dough", 4, "cup", "Carbohydrates", 200);
            AddIngredient("Tomato Sauce", 2, "cup", "Vegetables", 50);
            AddIngredient("Mozzarella Cheese", 1.5, "cup", "Dairy", 200);
            AddIngredient("Pepperoni", 10, "slices", "Proteins", 150);
            AddIngredient("Mushrooms", 2, "cup", "Vegetables", 30);

            AddStep(1, "Preheat the oven to 200°C.");
            AddStep(2, "Roll out the pizza dough into a round shape.");
            AddStep(3, "Spread the tomato sauce evenly on the dough.");
            AddStep(4, "Sprinkle the mozzarella cheese on top of the sauce.");
            AddStep(5, "Add the pepperoni and mushrooms as desired.");
            AddStep(6, "Bake the pizza in the preheated oven for 15-20 minutes.");

            recipes.Add(new Recipe("Pizza", ingredients, instructions, 1));
        }

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
            MessageBox.Show("Recipe added successfully! Total number of recipes is now " + recipes.Count);
        }

        public double CalculateTotalCalories(string recipeName)
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
            string result = "";

            foreach (Recipe recipe in recipes)
            {
                result += recipe.name + "\n";
            }

            return result;
        }

        public string DisplayRecipe(string recipeName)
        {
            string result = "";

            foreach (Recipe recipe in recipes)
            {
                if (recipe.name == recipeName)
                {
                    result += "Recipe Name: " + recipe.name + "\n";
                    result += "Ingredients:\n";
                    foreach (Ingredient ingredient in recipe.Ingredients)
                    {
                        result += "- " + ingredient.name + "\t" + ingredient.quantity + "\t" + ingredient.unit + "\t" + ingredient.calories + "\n";
                    }
                    result += "\nInstructions:\n";
                    foreach (Instruction instruction in recipe.Instructions)
                    {
                        result += "> " + instruction.step + "\n";
                    }
                    break;
                }
            }

            return result;
        }

        public string DisplayRecipeIngredient(string ingName)
        {
            string result = "";

            foreach (Recipe recipe in recipes)
            {
                foreach (Ingredient ingredient in recipe.Ingredients)
                {
                    if (ingredient.name == ingName)
                    {
                        result += recipe.name + "\n";
                        break;
                    }
                }
            }

            return result;
        }

        public string DisplayRecipeGroup(string foodGroup)
        {
            string result = "";

            foreach (Recipe recipe in recipes)
            {
                foreach (Ingredient ingredient in recipe.Ingredients)
                {
                    if (ingredient.foodGroup == foodGroup)
                    {
                        result += recipe.name + "\n";
                        break;
                    }
                }
            }

            return result;
        }

        public string DisplayRecipeMaxCalories(double numCalories)
        {
            string result = "";

            foreach (Recipe recipe in recipes)
            {
                double totalCalories = 0;
                foreach (Ingredient ingredient in recipe.Ingredients)
                {
                    totalCalories += ingredient.calories;
                }

                if (totalCalories <= numCalories)
                {
                    result += recipe.name + "\n";
                }
            }

            return result;
        }

        public string DeleteRecipe(string recipeName)
        {
            bool found = false;

            foreach (Recipe recipe in recipes)
            {
                if (recipe.name == recipeName)
                {
                    recipes.Remove(recipe);
                    found = true;
                    break;
                }
            }

            if (found)
            {
                return "Recipe Successfully Erased!";
            }
            else
            {
                return "Recipe not found?";
            }
        }

        public void ScaleRecipe(string recipeName, double scale)
        {
            foreach (Recipe recipe in recipes)
            {
                if (recipe.name == recipeName)
                {
                    foreach (Ingredient ingredient in recipe.Ingredients)
                    {
                        ingredient.quantity *= scale;
                        ingredient.calories *= scale;
                    }

                    recipe.scale *= scale;
                }
            }
        }

        public void RescaleRecipe(string recipeName)
        {
            foreach (Recipe recipe in recipes)
            {
                if (recipe.name == recipeName)
                {
                    foreach (Ingredient ingredient in recipe.Ingredients)
                    {
                        ingredient.quantity /= recipe.scale;
                        ingredient.calories /= recipe.scale;
                    }

                    recipe.scale /= recipe.scale;
                }
            }
        }
    }
}
