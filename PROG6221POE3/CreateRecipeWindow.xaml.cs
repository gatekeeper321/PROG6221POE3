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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

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
            method.AddRecipe(recipeName);

            gridRecipe.Visibility = Visibility.Visible;

            btnBack.IsEnabled = true;
            btnSubmit.IsEnabled = false;
        }

        private void AddIngredients(object sender, RoutedEventArgs e)
        {
            recipeName = txtRecipeName.Text;
            numIngredients = Convert.ToInt32(txtNumIngredients.Text);
            numSteps = Convert.ToInt32(txtNumSteps.Text);
            countIng = 0;
            countStep = 0;

            txtIngName.Text = "";
            txtQuantity.Text = "";
            txtNumSteps.Text = "";

            btnBack.IsEnabled = false;
            gridIngredient.Visibility = Visibility.Visible;
            gridRecipe.Visibility = Visibility.Hidden;
        }
        
        private void NextIngredient(object sender, RoutedEventArgs e)
        {
            ingName = txtIngName.Text;
            ingQuantity = Convert.ToDouble(txtQuantity.Text);
            ingUnit = cmbMeasurement.SelectedItem.ToString();
            ingFoodGroup = cmbFoodGroup.SelectedItem.ToString();
            ingnumCalories = Convert.ToDouble(txtNumCalories.Text);

            txtIngName.Text = "";
            txtQuantity.Text = "";
            cmbMeasurement.SelectedIndex = -1;
            cmbFoodGroup.SelectedIndex = -1;
            txtNumCalories.Text = "";

            countIng++;
            if (countIng >= numIngredients)
            {
                gridSteps.Visibility = Visibility.Visible;
                gridIngredient.Visibility = Visibility.Hidden;
            }
            else 
            {
                method.AddIngredient(ingName, ingQuantity, ingUnit, ingFoodGroup, ingnumCalories);
            }
            
        }

        private void NextStep(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(rtbStep.Document.ContentStart, rtbStep.Document.ContentEnd);
            string text = textRange.Text;

            countStep++;

            if (countStep >= numSteps)
            {
                gridSteps.Visibility = Visibility.Hidden;
                btnSubmit.IsEnabled = true;
            }
            else
            {
                method.AddStep(countStep, text);
                rtbStep.Document.Blocks.Clear();
            }
        }
    }
}
