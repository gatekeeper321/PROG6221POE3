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

namespace PROG6221POE3
{
    public partial class CreateRecipeWindow : Window
    {
        Methods.Method method = new Methods.Method();

        string recipeName;
        int numIngredients;
        int numSteps;

        int countIng;
        int countStep;

        string ingName;
        double ingQuantity;
        string ingUnit;
        string ingFoodGroup;
        double ingnumCalories;

        private MainWindow mainWindow;

        public CreateRecipeWindow()
        {
            InitializeComponent();
        }


        private void Back(object sender, RoutedEventArgs e)
        {
            if (mainWindow == null || !mainWindow.IsLoaded)
            {
                mainWindow = new MainWindow();
                mainWindow.Show();
                this.Hide();
            }
            else
            {
                mainWindow.Focus();
            }
        }

        private void Submit(object sender, RoutedEventArgs e)
        {
            try
            {
                recipeName = txtRecipeName.Text;
                method.AddRecipe(recipeName);

                gridRecipe.Visibility = Visibility.Visible;

                btnSubmit.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        private void AddIngredients(object sender, RoutedEventArgs e)
        {
            try
            {
                numIngredients = int.Parse(txtNumIngredients.Text);
                numSteps = int.Parse(txtNumSteps.Text);

                gridIngredient.Visibility = Visibility.Visible;
                gridRecipe.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void NextIngredient(object sender, RoutedEventArgs e)
        {
            try
            {
                ingName = txtIngName.Text;
                ingQuantity = double.Parse(txtQuantity.Text);
                ingUnit = cmbMeasurement.SelectedItem?.ToString();
                ingFoodGroup = cmbFoodGroup.SelectedItem?.ToString();
                ingnumCalories = double.Parse(txtNumCalories.Text);

                countIng++;
                method.AddIngredient(ingName, ingQuantity, ingUnit, ingFoodGroup, ingnumCalories);

                txtIngName.Text = "";
                txtQuantity.Text = "";
                cmbMeasurement.SelectedIndex = -1;
                cmbFoodGroup.SelectedIndex = -1;
                txtNumCalories.Text = "";

                if (countIng >= numIngredients)
                {
                    gridSteps.Visibility = Visibility.Visible;
                    gridIngredient.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void NextStep(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(rtbStep.Document.ContentStart, rtbStep.Document.ContentEnd);
            string text = textRange.Text;

            countStep++;
            method.AddStep(countStep, text);

            if (countStep >= numSteps)
            {
                gridSteps.Visibility = Visibility.Hidden;
                btnSubmit.IsEnabled = true;
            }
        }
    }
}
