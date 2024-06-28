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
using PROG6221POE3.Methods;

namespace PROG6221POE3
{
    public partial class DeleteRecipeWindow : Window
    {
        string ingName;
        string foodGroup;
        string recipeName;

        double numCalories;

        private MainWindow mainWindow;
        private Methods.Method method = new Method();



        public DeleteRecipeWindow()
        {
            InitializeComponent();
        }

        private void DeleteRecipe(object sender, RoutedEventArgs e)
        {
            recipeName = txtDeleteRecipe.Text;
            MessageBox.Show(method.DeleteRecipe(recipeName));
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
