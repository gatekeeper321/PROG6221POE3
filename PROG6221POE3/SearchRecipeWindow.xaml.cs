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
    public partial class SearchRecipeWindow : Window 
    {
        //instantiating windows
        private MainWindow mainWindow;
        private Methods.Method method;

        public SearchRecipeWindow(MainWindow mainWindow, Method method) //constructor
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.method = method;
        }

        private void SearchName(object sender, RoutedEventArgs e) //search by name button
        {
            string recipeName = txtSearchRecipeName.Text;
            string result = method.DisplayRecipe(recipeName);
            txtBlock.Text = result;
        }

        private void SearchGroup(object sender, RoutedEventArgs e) //search by food group button
        {
            ComboBoxItem selectedGroup = (ComboBoxItem)cmbFoodGroup.SelectedItem;
            string foodGroup = selectedGroup.Content.ToString();

            if (foodGroup != null)
            {
                string result = method.DisplayRecipeGroup(foodGroup);
                txtBlock.Text = result;
            }
        }

        private void SearchIngredient(object sender, RoutedEventArgs e) //search by ingredient button
        {
            string ingName = txtSearchIngredient.Text;
            string result = method.DisplayRecipeIngredient(ingName);
            txtBlock.Text = result;
        }

        private void SearchCalories(object sender, RoutedEventArgs e) //search by max numver of calories button
        {
            double numCalories = double.Parse(txtSearchCalories.Text);
            string result = method.DisplayRecipeMaxCalories(numCalories);
            txtBlock.Text = result;
        }

        private void Back(object sender, RoutedEventArgs e) //back button
        {
            mainWindow.Show();
            this.Close();
        }

        private void SearchAll_Click(object sender, RoutedEventArgs e) //search for all recipes buton
        {
            string result = method.DisplayAllRecipes();
            txtBlock.Text = result;
        }
    }
}
