using PROG6221POE3.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//MCPETRIE-ST10263164-PROG6221POE3
namespace PROG6221POE3
{
    public partial class CreateRecipeWindow : Window
    {
        string recipeName;
        int numIngredients;
        int numSteps;
        int countIng;
        int countStep;
        string ingName;
        double ingQuantity;
        double ingnumCalories;

        //instantiating windows
        private MainWindow mainWindow;
        private Method method;

        public CreateRecipeWindow(MainWindow mainWindow, Method method) //constructor
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.method = method;
        }

        private void Back(object sender, RoutedEventArgs e) //back button
        {
            mainWindow.Show();
            this.Close();
        }

        private void Submit(object sender, RoutedEventArgs e) //submit button
        {
            try //try catch to catch any errors
            {
                recipeName = txtRecipeName.Text;
                method.AddRecipe(recipeName);

                txtRecipeName.Text = ""; //clears recipe name text

                gridRecipe.Visibility = Visibility.Visible; //makes the first part of the recipe menu visible again

                btnSubmit.IsEnabled = false; //disables submit button
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); //error message for any exceptions
            }
        }

        private void AddIngredients(object sender, RoutedEventArgs e) // this button adds ingredient and step numbers for the recipe
        {
            try
            {
                numIngredients = int.Parse(txtNumIngredients.Text);
                numSteps = int.Parse(txtNumSteps.Text);

                txtNumIngredients.Text = "";
                txtNumSteps.Text = "";

                gridIngredient.Visibility = Visibility.Visible; //shows next add ingredient of the recipe menu
                gridRecipe.Visibility = Visibility.Hidden; //hides the first part of the recipe menu
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); //error message for any exceptions
            }
        }

        private void NextIngredient(object sender, RoutedEventArgs e) //adds the ingredients to the recipe
        {
            try
            {
                ingName = txtIngName.Text;
                ingQuantity = double.Parse(txtQuantity.Text);

                ComboBoxItem selectedGroup = (ComboBoxItem)cmbFoodGroup.SelectedItem; //gets the selected item from the combobox
                string ingFoodGroup = selectedGroup.Content.ToString(); //converts the selected item to a string

                ComboBoxItem selectedUnit = (ComboBoxItem)cmbMeasurement.SelectedItem; //gets the selected item from the combobox
                string ingUnit = selectedUnit.Content.ToString(); //converts the selected item to a string

                ingnumCalories = double.Parse(txtNumCalories.Text);

                countIng++;
                method.AddIngredient(ingName, ingQuantity, ingUnit, ingFoodGroup, ingnumCalories); //calls the add ingredient method

                txtIngName.Text = "";
                txtQuantity.Text = "";
                cmbMeasurement.SelectedIndex = -1;
                cmbFoodGroup.SelectedIndex = -1;
                txtNumCalories.Text = "";

                if (countIng >= numIngredients)
                {
                    gridSteps.Visibility = Visibility.Visible; //shows add step section of the recipe menu
                    gridIngredient.Visibility = Visibility.Hidden; //hides the ingredient menu
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); //error message for any exceptions
            }
        }

        private void NextStep(object sender, RoutedEventArgs e) //adds the steps to the recipe
        {
            TextRange textRange = new TextRange(rtbStep.Document.ContentStart, rtbStep.Document.ContentEnd);
            string text = textRange.Text;

            countStep++;
            method.AddStep(countStep, text); //calls the add step method

            textRange.Text = "";

            if (countStep >= numSteps)
            {
                gridSteps.Visibility = Visibility.Hidden; //hides the add step section of the recipe menu
                btnSubmit.IsEnabled = true; //enables button so recipe may be created
            }
        }
    }
}
