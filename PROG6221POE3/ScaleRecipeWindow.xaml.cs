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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ScaleRecipeWindow : Window
    {
        private Methods.Method method = new Method();
        MainWindow mainWindow = new MainWindow();

        double scale;
        string recipeName;

        public ScaleRecipeWindow()
        {
            InitializeComponent();
        }

        private void btnScaleRecipe_click(object sender, RoutedEventArgs e)
        {
            recipeName = txtScaleRecipe.Text;
            scale = int.Parse(cmbScale.SelectedItem?.ToString());
            method.ScaleRecipe(recipeName, scale);
            MessageBox.Show("Recipe has been scaled by " + scale + "x");
        }

        private void btnRescaleRecipe_click(object sender, RoutedEventArgs e)
        {
            recipeName = txtRecipeRescale.Text;
            method.RescaleRecipe(recipeName);
            MessageBox.Show("Recipe has been rescaled");
        }

        private void btnBackfromScale_click(object sender, RoutedEventArgs e)
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

        private void ScaleRecipe(object sender, RoutedEventArgs e)
        {

        }
    }
}
