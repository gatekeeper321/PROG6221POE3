using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
//MCPETRIE-ST10263164-PROG6221POE3
namespace PROG6221POE3.Methods
{
    public class Method 
    {
        List<Recipe> recipes = new List<Recipe>(); //initializing list
        List<Ingredient> ingredients = new List<Ingredient>(); //initializing list
        List<Instruction> instructions = new List<Instruction>(); //initializing list

        public void AddIngredient(string ingName, double ingQuantity, string ingUnit, string ingFoodGroup, double ingNumCalories) //add ingredient
        {
            ingredients.Add(new Ingredient(ingName, ingFoodGroup, ingUnit, ingQuantity, ingNumCalories)); // adds ingredient to list of ingredients
        }

        public void AddStep(int countStep, string text) //add step
        {
            instructions.Add(new Instruction(countStep, text)); //adds instruction to list of instructions
        }

        
        public void AddRecipe(string recipeName) //addrecipe
        {
            List<Ingredient> recipeIngredients = new List<Ingredient>(ingredients); //this copies list of ingredients to recipeIngredients
            List<Instruction> recipeInstructions = new List<Instruction>(instructions); //this copies list of instructions to recipeInstructions

            recipes.Add(new Recipe(recipeName, recipeIngredients, recipeInstructions, 1));//creating recipe object

            MessageBox.Show("Recipe has been successfully added!"); 

            instructions.Clear(); //clearing lists otherwise it will continiously expand with each new recipe
            ingredients.Clear();
        }

        public double CalculateTotalCalories(string recipeName) //calculates total calories in a recipe
        {
            double totalCalories = 0;

            foreach (Recipe recipe in recipes) //loops through each recipe in the list of recipes
            {
                if (recipe.name == recipeName)
                {
                    foreach (Ingredient ingredient in recipe.Ingredients) //loops through each ingredient in the recipe
                    {
                        totalCalories += ingredient.calories;
                    }
                }
            }
            return totalCalories;
        }

        public string DisplayAllRecipes() //displays all recipes
        {
            string result = "";

            recipes = recipes.OrderBy(r => r.name).ToList(); //order recipes alphabetically

            foreach (Recipe recipe in recipes) //loops through each recipe in the list of recipes
            {
                result += "Recipe Name: " + recipe.name + "\n";
                result += "Ingredients:\n";
                foreach (Ingredient ingredient in recipe.Ingredients) //loops through each ingredient in the recipe
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

        public string DisplayRecipe(string recipeName) //displays 1 recipe based on given name
        {
            string result = "";

            recipes = recipes.OrderBy(r => r.name).ToList(); //order recipes alphabetically

            foreach (Recipe recipe in recipes) //loops through each recipe in the list of recipes
            {
                if (recipe.name == recipeName)
                {
                    result += "Recipe Name: " + recipe.name + "\n";
                    result += "Ingredients:\n";
                    foreach (Ingredient ingredient in recipe.Ingredients) //loops through each ingredient in the recipe
                    {
                        result += "> " + ingredient.name + "\t" + ingredient.quantity + " " + ingredient.unit + "\tcalories:" + ingredient.calories + "\n";
                    }
                    result += "\nInstructions:\n";
                    foreach (Instruction instruction in recipe.Instructions) //loops through each instruction in the recipe
                    {
                        result += "> " + instruction.step + "\n";
                    }
                    break;
                }
            }

            return result;
        }

        public string DisplayRecipeIngredient(string ingName) //display all recipes with specific ingredient
        {
            string result = "Recipes with " + ingName + ":\n\n"; 
            int count = 0;

            recipes = recipes.OrderBy(r => r.name).ToList(); //order recipes alphabetically

            foreach (Recipe recipe in recipes) //loops through each recipe in the list of recipes
            {
                foreach (Ingredient ingredient in recipe.Ingredients) //loops through each ingredient in the recipe
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

        public string DisplayRecipeGroup(string foodGroup) //displays all recipes with specific food group
        {
            string result = "Recipes that have " + foodGroup + "\n\n";
            int count = 0;

            recipes = recipes.OrderBy(r => r.name).ToList(); //order recipes alphabetically

            foreach (Recipe recipe in recipes) //loops through each recipe in the list of recipes
            {
                bool found = false;
                foreach (Ingredient ingredient in recipe.Ingredients) //loops through each ingredient in the recipe
                {
                    if (ingredient.foodGroup == foodGroup)
                    {
                        found = true;
                        break;
                    }
                }
                if (found) //adds recipe if food group is found
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

            recipes = recipes.OrderBy(r => r.name).ToList(); //order recipes alphabetically

            foreach (Recipe recipe in recipes) //loops through each recipe in the list of recipes
            {
                if (CalculateTotalCalories(recipe.name) <= numCalories)
                {
                    result += recipe.name + "\n";
                }
            }

            return result;
        }

        public string DeleteRecipe(string recipeName) //deltes recipe based on given name
        {
            bool found = false;

            foreach (Recipe recipe in recipes) //loops through each recipe in the list of recipes
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

        public void ScaleRecipe(string recipeName, double scale) //scales recipe based on given scale
        {
            bool found = false;

            foreach (Recipe recipe in recipes) //loops through each recipe in the list of recipes
            {
                if (recipe.name == recipeName)
                {
                    foreach (Ingredient ingredient in recipe.Ingredients) //loops through each ingredient in the recipe
                    {
                        ingredient.quantity *= scale; // all quantities are multiplied by scale
                        ingredient.calories *= scale; // all calories are multiplied by scale
                        found = true;
                    }

                    recipe.scale *= scale; // scale is also multiplayed by scale to keep track of how much it has been scaled
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

        public void RescaleRecipe(string recipeName) //rescale recipe to original dimensions
        {
            bool found = false;

            foreach (Recipe recipe in recipes) //loops through each recipe in the list of recipes
            {
                if (recipe.name == recipeName)
                {
                    foreach (Ingredient ingredient in recipe.Ingredients) //loops through each ingredient in the recipe
                    {
                        ingredient.quantity /= recipe.scale; // all quantities are dividided by scale to return too original values
                        ingredient.calories /= recipe.scale; // all calories are dividided by scale to return too original values
                        found = true;
                    }

                    recipe.scale /= recipe.scale; //recipe scale also returns to original value of 1 so it can be known that is its original state
                }

                if (found) //if to send message based on whther or not recipe was found
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
