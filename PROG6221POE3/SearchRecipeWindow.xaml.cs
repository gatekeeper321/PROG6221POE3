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

namespace PROG6221POE3
{
    public partial class SearchRecipeWindow : Window
    {
        private MainWindow mainWindow;
        private Methods.Method method;

        public SearchRecipeWindow(MainWindow mainWindow, Method method)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.method = method;
        }

        private void SearchName(object sender, RoutedEventArgs e)
        {
            string recipeName = txtSearchRecipeName.Text;
            string result = method.DisplayRecipe(recipeName);
            txtBlock.Text = result;
        }

        private void SearchGroup(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedGroup = (ComboBoxItem)cmbFoodGroup.SelectedItem;
            string foodGroup = selectedGroup.Content.ToString();

            if (foodGroup != null)
            {
                string result = method.DisplayRecipeGroup(foodGroup);
                txtBlock.Text = result;
            }
        }

        private void SearchIngredient(object sender, RoutedEventArgs e)
        {
            string ingName = txtSearchIngredient.Text;
            string result = method.DisplayRecipeIngredient(ingName);
            txtBlock.Text = result;
        }

        private void SearchCalories(object sender, RoutedEventArgs e)
        {
            double numCalories = double.Parse(txtSearchCalories.Text);
            string result = method.DisplayRecipeMaxCalories(numCalories);
            txtBlock.Text = result;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            mainWindow.Show();
            this.Close();
        }

        private void SearchAll_Click(object sender, RoutedEventArgs e)
        {
            string result = method.DisplayAllRecipes();
            txtBlock.Text = result;
            MessageBox.Show(result);
        }
    }
}
