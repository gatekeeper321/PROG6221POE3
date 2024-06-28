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
        private Method method;
        private MainWindow mainWindow;

        double scale;
        string recipeName;

        public ScaleRecipeWindow(MainWindow mainWindow, Method method)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.method = method;
        }

        private void btnScaleRecipe_click(object sender, RoutedEventArgs e)
        {
            recipeName = txtScaleRecipe.Text;

            ComboBoxItem selectedScale = (ComboBoxItem)cmbScale.SelectedItem;
            double scale = double.Parse(selectedScale.Content.ToString());

            method.ScaleRecipe(recipeName, scale);
        }

        private void btnRescaleRecipe_click(object sender, RoutedEventArgs e)
        {
            recipeName = txtRecipeRescale.Text;
            method.RescaleRecipe(recipeName);
        }

        private void btnBackfromScale_click(object sender, RoutedEventArgs e)
        {
            mainWindow.Show();
            this.Close();
        }
    }
}
