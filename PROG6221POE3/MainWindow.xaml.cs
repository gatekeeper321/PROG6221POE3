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
    public partial class MainWindow : Window
    {
        private CreateRecipeWindow createRecipeWindow;
        private SearchRecipeWindow searchRecipeWindow;
        private ScaleRecipeWindow scaleRecipeWindow;
        private DeleteRecipeWindow deleteRecipeWindow;
        private Methods.Method method;

        public MainWindow()
        {
            InitializeComponent();
            this.method = new Methods.Method();
        }

        private void OpenCreateRecipe(object sender, RoutedEventArgs e) //open create recipe window
        {
            if (createRecipeWindow == null || !createRecipeWindow.IsLoaded)
            {
                createRecipeWindow = new CreateRecipeWindow(this, method);
                createRecipeWindow.Show();
                this.Hide();
            }
            else
            {
                createRecipeWindow.Focus();
            }
        }

        private void OpenSearchRecipe(object sender, RoutedEventArgs e) //open search recipe window
        {
            if (searchRecipeWindow == null || !searchRecipeWindow.IsLoaded)
            {
                searchRecipeWindow = new SearchRecipeWindow(this, method);
                searchRecipeWindow.Show();
                this.Hide();
            }
            else
            {
                searchRecipeWindow.Focus();
            }
        }

        private void OpenRecipeScaling(object sender, RoutedEventArgs e)//open scale recipe window
        {
            if (scaleRecipeWindow == null || !scaleRecipeWindow.IsLoaded)
            {
                scaleRecipeWindow = new ScaleRecipeWindow(this, method);
                scaleRecipeWindow.Show();
                this.Hide();
            }
            else
            {
                searchRecipeWindow.Focus();
            }
        }

        private void btnOpenDelete_Click(object sender, RoutedEventArgs e) //open delete recipe window
        {
            if (deleteRecipeWindow == null || !deleteRecipeWindow.IsLoaded)
            {
                deleteRecipeWindow = new DeleteRecipeWindow(this, method);
                deleteRecipeWindow.Show();
                this.Hide();
            }
            else
            {
                searchRecipeWindow.Focus();
            }
        }

        private void ExitApp(object sender, RoutedEventArgs e) //exit application button
        {
            Application.Current.Shutdown();
        }
    }
}
