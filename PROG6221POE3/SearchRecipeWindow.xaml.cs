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
    public partial class SearchRecipeWindow : Window
    {
        string ingName;
        string foodGroup;
        string recipeName;
        double numCalories;

        private MainWindow mainWindow;
        private Methods.Method method = new Methods.Method();

        public SearchRecipeWindow()
        {
            InitializeComponent();
        }

        private void SearchName(object sender, RoutedEventArgs e)
        {
            string recipeName = txtSearchRecipeName.Text;
            string result = method.DisplayRecipe(recipeName);
            txtBlock.Text = result;
        }

        private void SearchGroup(object sender, RoutedEventArgs e)
        {
            foodGroup = cmbFoodGroup.SelectedItem.ToString();
            string result = method.DisplayRecipeIngredient(foodGroup);
            txtBlock.Text = result;
        }

        private void SearchIngredient(object sender, RoutedEventArgs e)
        {
            string ingName = txtSearchRecipeName.Text;
            string result = method.DisplayRecipeIngredient(ingName);
            txtBlock.Text = result;
        }

        private void SearchCalories(object sender, RoutedEventArgs e)
        {
            double numCalories = Convert.ToDouble(txtSearchCalories.Text);
            string result = method.DisplayRecipeMaxCalories(numCalories);
            txtBlock.Text = result;
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
        private void CreateRecipe(object sender, RoutedEventArgs e)
        {
            string recipeName = txtSearchRecipeName.Text;
            method.AddRecipe(recipeName);
        }

        private void SearchAll_Click(object sender, RoutedEventArgs e)
        {
            string result = method.DisplayAllRecipes();
            txtBlock.Text = result;
            MessageBox.Show(result);
        }
    }
}
