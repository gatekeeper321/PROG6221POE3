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
            recipeName = txtSearchName.Text;
            rtbDisplay.AppendText(method.DisplayRecipe(recipeName));
        }

        private void SearchGroup(object sender, RoutedEventArgs e)
        {
            foodGroup = cmbFoodGroup.SelectedItem.ToString();
            rtbDisplay.AppendText(method.DisplayRecipeIngredient(foodGroup));
        }

        private void SearchIngredient(object sender, RoutedEventArgs e)
        {
            ingName = txtSearchRecipeName.Text;
            rtbDisplay.AppendText(method.DisplayRecipeIngredient(ingName));
        }

        private void SearchAll(object sender, RoutedEventArgs e)
        {
            rtbDisplay.AppendText(method.DisplayAllRecipes());
        }

        private void SearchCalories(object sender, RoutedEventArgs e)
        {
            numCalories = Convert.ToDouble(txtSearchCalories.Text);
            rtbDisplay.AppendText(method.DisplayRecipeMaxCalories(numCalories));
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
    }
}
