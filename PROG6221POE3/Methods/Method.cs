using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace PROG6221POE3.Methods
{
    public class Method 
    {
        //CreateRecipeWindow createRecipeWindow;

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
            List<Ingredient> recipeIngredients = new List<Ingredient>(ingredients);
            List<Instruction> recipeInstructions = new List<Instruction>(instructions);

            recipes.Add(new Recipe(recipeName, recipeIngredients, recipeInstructions, 1));

            MessageBox.Show("Recipe has been successfully added!");

            instructions.Clear();
            ingredients.Clear();
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
                result += "Recipe Name: " + recipe.name + "\n";
                result += "Ingredients:\n";
                foreach (Ingredient ingredient in recipe.Ingredients)
                {
                    result += "> " + ingredient.name + "\t" + ingredient.quantity + " " + ingredient.unit + "\tcalories:" + ingredient.calories + "\n";
                }
                result += "\nInstructions:\n";
                foreach (Instruction instruction in recipe.Instructions)
                {
                    result += "> " + instruction.step + "\n\n";
                }
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
                        result += "> " + ingredient.name + "\t" + ingredient.quantity + " " + ingredient.unit + "\tcalories:" + ingredient.calories + "\n";
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
            string result = "Recipes with " + ingName + ":\n\n"; 
            int count = 0;

            foreach (Recipe recipe in recipes)
            {
                foreach (Ingredient ingredient in recipe.Ingredients)
                {
                    if (ingredient.name == ingName)
                    {
                        count++;
                        result += count + ") " + recipe.name + "\n";
                    }
                }
            }

            return result;
        }

        public string DisplayRecipeGroup(string foodGroup)
        {
            string result = "Recipes that have " + foodGroup + "\n\n";
            int count = 0;

            foreach (Recipe recipe in recipes)
            {
                bool found = false;
                foreach (Ingredient ingredient in recipe.Ingredients)
                {
                    if (ingredient.foodGroup == foodGroup)
                    {
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    count++;
                    result += count + ") " + recipe.name + "\n";
                }
            }

            return result;
        }

        public string DisplayRecipeMaxCalories(double numCalories)
        {
            string result = "Recipes with a max of " + numCalories + " calories:\n\n";

            foreach (Recipe recipe in recipes)
            {
                if (CalculateTotalCalories(recipe.name) <= numCalories)
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
            bool found = false;

            foreach (Recipe recipe in recipes)
            {
                if (recipe.name == recipeName)
                {
                    foreach (Ingredient ingredient in recipe.Ingredients)
                    {
                        ingredient.quantity *= scale;
                        ingredient.calories *= scale;
                        found = true;
                    }

                    recipe.scale *= scale;
                }

                if (found) 
                {
                    MessageBox.Show("Recipe has been scaled by " + scale + "x");
                }
                else
                {
                    MessageBox.Show("Recipe entered was not found");
                }
            }
        }

        public void RescaleRecipe(string recipeName)
        {
            bool found = false;

            foreach (Recipe recipe in recipes)
            {
                if (recipe.name == recipeName)
                {
                    foreach (Ingredient ingredient in recipe.Ingredients)
                    {
                        ingredient.quantity /= recipe.scale;
                        ingredient.calories /= recipe.scale;
                        found = true;
                    }

                    recipe.scale /= recipe.scale;
                }

                if (found)
                {
                    MessageBox.Show("Recipe has been rescaled");
                }
                else
                {
                    MessageBox.Show("Recipe entered was not found");
                }
            }
        }
    }
}
