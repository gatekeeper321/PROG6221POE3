/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//MCPETRIE-ST10263164-PROG6221POE3
namespace PROG6221POEPART2
{
    internal class Methods
    {
        List<Recipe> recipes = new List<Recipe>();
        List<Ingredient> ingredients = new List<Ingredient>();
        List<Instruction> instructions = new List<Instruction>();

        public event Action<string> ExceededCalories;

        public string CreateRecipe()
        {
            bool add = true;
            bool valid = false;

            string recipeName = "";
            double recipeScale = 1;

            string ingredientName = "";
            string ingredientGroup = "";
            string ingredientUnit = "";
            double ingredientQuantity = 0;
            double ingredientCalories = 0;

            int stepNumber = 0;
            string step = "";

            string select = "";

            Console.Clear();

            Console.WriteLine("Enter the name of the recipe you would like to add: ");
            recipeName = Console.ReadLine();

            while (add) //loops until user decides to stop adding ingredients
            {
                //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                Console.WriteLine("Enter the name of the ingredient you would like to add: ");
                ingredientName = Console.ReadLine();
                //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                // the below code is used to validate user input so that they can only enter a number between 1 and 5 which corresponds to a ffod group, it will loop until a valid input
                //i desgined it like this because it feels much more streamline in the console application and in the future if i wish to select recipes with a specific food group it will be easier to do so
                Console.WriteLine("Enter the food group which " + ingredientName + " belongs to:\n1) Carbohydrates\n2) Dairy\n3) Fats & Oils\n4) Fruits & Vegetables\n5) Protein");
                select = Console.ReadLine();
                valid = false;
                while (!valid)
                {
                    if (select == "1")
                    {
                        ingredientGroup = "Carbohydrates";
                        valid = true;
                    }
                    else if (select == "2")
                    {
                        ingredientGroup = "Dairy";
                        valid = true;
                    }
                    else if (select == "3")
                    {
                        ingredientGroup = "Fats & Oils";
                        valid = true;
                    }
                    else if (select == "4")
                    {
                        ingredientGroup = "Fruits & Vegetables";
                        valid = true;
                    }
                    else if (select == "5")
                    {
                        ingredientGroup = "Protein";
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.\nEnter the food group which \n" + ingredientName + " belongs to:\n1) Carbohydrates\n2) Dairy\n3) Fats & Oils\n4) Fruits & Vegetables\n5) Protein");
                        select = Console.ReadLine();
                    }
                }
                //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                // the below code is used to validate user input so that they can only enter a number between 1 and 5 which corresponds to a ffod group, it will loop until a valid input
                //i designed it this way so that the measurement units could be easily used to change with the scale of the recipe
                Console.WriteLine("Choose the measurement type for " + ingredientName + ":\n1) Drops\n2) Teaspoons\n3) Tablespoons\n4) Cups\n5) Whole (for items like eggs/avocados/etc. )");
                select = Console.ReadLine();
                valid = false;
                while (!valid)
                {
                    if (select == "1")
                    {
                        ingredientUnit = "Drops"; //smallest unit, for things like vanilla extract, food coloring, etc.
                        valid = true;
                    }
                    else if (select == "2")
                    {
                        ingredientUnit = "Teaspoons";
                        valid = true;
                    }
                    else if (select == "3")
                    {
                        ingredientUnit = "Tablespoons";
                        valid = true;
                    }
                    else if (select == "4")
                    {
                        ingredientUnit = "Cups";
                        valid = true;
                    }
                    else if (select == "5")
                    {
                        ingredientUnit = "Wholes"; //wholes refers to items that have no measurement unit like eggs, avocados, etc.
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.\nChoose the measurement type for " + ingredientName + ":\n1) Drops\n2) Teaspoons\n3) Tablespoons\n4) Cups\n5) Whole (for items like eggs/avocados/etc. )");
                        select = Console.ReadLine();
                    }
                }
                //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                Console.WriteLine("Enter the amount of " + ingredientName + " (in " + ingredientUnit + "):");
                while (!double.TryParse(Console.ReadLine(), out ingredientQuantity)) //line of code inspired by answer generated by CHATGPT this code is used to validate user input
                {
                    Console.WriteLine("Invalid input. Please enter a valid answer.\nEnter the amount of " + ingredientName + " (in " + ingredientUnit + "):");
                }
                //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                Console.WriteLine("Enter the amount of calories in " + ingredientQuantity + " " + ingredientUnit + " of " + ingredientName + ":");
                while (!double.TryParse(Console.ReadLine(), out ingredientCalories)) //line of code inspired by answer generated by CHATGPT this code is used to validate user input
                {
                    Console.WriteLine("Invalid input. Please enter a valid answer.\nEnter the amount of calories in " + ingredientQuantity + " " + ingredientUnit + " of " + ingredientName + ":");
                }
                //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                Console.WriteLine("Would you like to add another ingredient?\n1)YES\n2)NO ");
                select = Console.ReadLine();
                valid = false;
                while (!valid) //this while loop is used to validate user input so that they can only enter 1 or 2 as an answer(YES/NO)
                {
                    if (select == "1")
                    {
                        add = true;
                        valid = true;
                    }
                    else if (select == "2")
                    {
                        add = false;
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.\nWould you like to add another ingredient?\n1) YES\n2) NO");
                        select = Console.ReadLine();
                        Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                    }
                }

                ingredients.Add(new Ingredient(ingredientName, ingredientGroup, ingredientUnit, ingredientQuantity, ingredientCalories));

            }
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //-----------------------------------------------------------end of add ingredient loop-------------------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            while (add)
            {
                stepNumber = stepNumber + 1;

                Console.WriteLine("Enter the description of this step: ");
                step = Console.ReadLine();

                Console.WriteLine("Would you like to add another step?\n1)YES\n2)NO ");
                select = Console.ReadLine();
                valid = false;
                while (!valid)
                {
                    if (select == "1")
                    {
                        add = true;
                        valid = true;
                    }
                    else if (select == "2")
                    {
                        add = false;
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.\nWould you like to add another instruction?\n1) YES\n2) NO");
                        select = Console.ReadLine();
                        Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                    }
                }

                instructions.Add(new Instruction(stepNumber, step));
            }
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //-----------------------------------------------------------end of add instruction loop------------------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            recipes.Add(new Recipe(recipeName, ingredients, instructions, recipeScale));
            return "Recipe Successfully Created!";

            //end of createrecipe method
        }

        public string ViewAllRecipes() //method to view all recipes in recipe list
        {
            string ToString = "";

            Console.Clear();

            recipes = recipes.OrderBy(r => r.name).ToList(); //Line of code by CHATGPT

            foreach (Recipe recipe in recipes)
            {
                ToString = ToString + "\t\tRecipe Name: " + recipe.name;
                ToString = ToString + "\n\nIngredient\t\tFood Group\t\tQuantity\t\tAmount of calories";

                foreach (Ingredient ingredient in recipe.Ingredients)
                {
                    ToString = ToString + "\n" + ingredient.name + "\t\t" + ingredient.foodGroup + "\t\t" + ingredient.quantity + " " + ingredient.unit + "\t\t" + ingredient.calories;
                }

                ToString = ToString + "\n\nTotal Calories: " + CalculateTotalCalories(recipe.name); //add total calories

                foreach (Instruction instruction in recipe.Instructions)
                {
                    ToString = ToString + "STEP " + instruction.stepNumber + "\n" + instruction.step;
                }

                ToString = ToString + "\n\n";
                Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            }
            return ToString;

        }

        public string ViewRecipe() //method to view a specific recipe in recipe list
        {
            string ToString = "";
            string recipeName = "";

            Console.Clear();

            Console.WriteLine("Enter the name of the recipe you would like to view:");
            recipeName = Console.ReadLine();

            foreach (Recipe recipe in recipes)
            {
                if (recipe.name == recipeName)
                {
                    ToString = ToString + "\t\tRecipe Name: " + recipe.name;
                    ToString = ToString + "\n\nIngredient\t\tFood Group\t\tQuantity\t\tAmount of calories\n";

                    foreach (Ingredient ingredient in recipe.Ingredients)
                    {
                        ToString = ToString + ingredient.name + "\t\t" + ingredient.foodGroup + "\t\t" + ingredient.quantity + " " + ingredient.unit + "\t\t" + ingredient.calories;
                    }

                    ToString = ToString + "\n\nTotal Calories: " + CalculateTotalCalories(recipe.name); // add total caloires

                    foreach (Instruction instruction in recipe.Instructions)
                    {
                        ToString = ToString + "STEP " + instruction.stepNumber + "\n" + instruction.step;
                    }

                    ToString = ToString + "\n\n";
                }

                Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            }
            return ToString;
        }

        public string ScaleRecipe() //method to scale a recipe
        {
            string recipeName = "";
            string select = "";

            bool valid = false;

            Console.Clear();

            Console.WriteLine("Enter the name of the recipe you would like to scale:");
            recipeName = Console.ReadLine();

            while (!valid)
            {
                Console.WriteLine("Choose how much you would like to scale the recipe by:\n1) half\n2) double\n3) triple");
                select = Console.ReadLine();

                if (select == "1")
                {
                    foreach (Recipe recipe in recipes)
                    {
                        if (recipe.name == recipeName)
                        {
                            recipe.scale = recipe.scale * 0.5;
                        }
                    }

                    valid = true;

                }
                else if (select == "2")
                {
                    foreach (Recipe recipe in recipes)
                    {
                        if (recipe.name == recipeName)
                        {
                            recipe.scale = recipe.scale * 2;
                        }
                    }

                    valid = true;

                }
                else if (select == "3")
                {
                    foreach (Recipe recipe in recipes)
                    {
                        if (recipe.name == recipeName)
                        {
                            recipe.scale = recipe.scale * 3;
                        }
                    }

                    valid = true;

                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }

                foreach (Recipe recipe in recipes)
                {
                    foreach (Ingredient ingredient in recipe.Ingredients)
                    {
                        ingredient.quantity = ingredient.quantity * recipe.scale;
                        ingredient.calories = ingredient.calories * recipe.scale;
                    }
                }
            }

            return "Recipe Successfully Scaled!";
        }

        public string RescaleRecipe() //method to rescale a recipe back to its original scale
        {
            Console.Clear();

            foreach (Recipe recipe in recipes)
            {
                foreach (Ingredient ingredient in recipe.Ingredients)
                {
                    ingredient.quantity = ingredient.quantity / recipe.scale;
                    ingredient.calories = ingredient.calories / recipe.scale;
                }

                recipe.scale = 1;
            }

            return "Recipe Successfully Rescaled!";
        }

        public string EraseRecipe() //method to erase a recipe
        {
            string recipeName = "";

            Console.Clear();

            Console.WriteLine("Enter the name of the recipe you would like to erase:");
            recipeName = Console.ReadLine();

            foreach (Recipe recipe in recipes)
            {
                if (recipe.name == recipeName)
                {
                    recipes.Remove(recipe);
                    break;
                }
            }

            return "Recipe Successfully Erased!";
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

        static void HandleExceededCalories(string message)
        {
            Console.WriteLine(message);
        }
        public void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
        }
    }
}
*/

