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
//MCPETRIE-ST10263164-PROG6221POE3
namespace PROG6221POE3
{
    public partial class DeleteRecipeWindow : Window
    {
        string recipeName;

        //instantiating windows
        private MainWindow mainWindow;
        private Method method;

        public DeleteRecipeWindow(MainWindow mainWindow, Method method) //constructor
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.method = method;
        }

        private void DeleteRecipe(object sender, RoutedEventArgs e) //delete recipe button
        {
            recipeName = txtDeleteRecipe.Text;
            method.DeleteRecipe(recipeName);
        }

        private void Back(object sender, RoutedEventArgs e) //back button
        {
            mainWindow.Show();
            this.Close();
        }
    }
}
