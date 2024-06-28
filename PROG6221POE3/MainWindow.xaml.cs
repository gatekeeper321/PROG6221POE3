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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // instantiating windows
        private CreateRecipeWindow createRecipeWindow;
        private SearchRecipeWindow searchRecipeWindow;
        private ScaleRecipeWindow scaleRecipeWindow;
        private DeleteRecipeWindow deleteRecipeWindow;
        private Methods.Method method;

        public MainWindow() //constructor
        {
            InitializeComponent();
            this.method = new Methods.Method();
        }

        private void OpenCreateRecipe(object sender, RoutedEventArgs e) //open create recipe window
        {
            if (createRecipeWindow == null || !createRecipeWindow.IsLoaded) // if create window is not open or loaded it will initialize it
            {
                createRecipeWindow = new CreateRecipeWindow(this, method); //passes main window and method so recipes do no get erased
                createRecipeWindow.Show(); //shows create recipe window
                this.Hide(); //hides main window
            }
            else
            {
                createRecipeWindow.Focus(); //focuses on create window
            }
        }

        private void OpenSearchRecipe(object sender, RoutedEventArgs e) //open search recipe window
        {
            if (searchRecipeWindow == null || !searchRecipeWindow.IsLoaded) // if search window is not open or loaded it will initialize it
            {
                searchRecipeWindow = new SearchRecipeWindow(this, method); //passes main window and method so recipes do no get erased
                searchRecipeWindow.Show(); //shows search recipe window
                this.Hide(); //hides main window
            }
            else
            {
                searchRecipeWindow.Focus(); //focuses on search window
            }
        }

        private void OpenRecipeScaling(object sender, RoutedEventArgs e)//open scale recipe window
        {
            if (scaleRecipeWindow == null || !scaleRecipeWindow.IsLoaded) // if scale window is not open or loaded it will initialize it
            {
                scaleRecipeWindow = new ScaleRecipeWindow(this, method); //passes main window and method so recipes do no get erased
                scaleRecipeWindow.Show(); //shows scale recipe window
                this.Hide(); //hides main window
            }
            else
            {
                searchRecipeWindow.Focus(); //focuses on scale window
            }
        }

        private void btnOpenDelete_Click(object sender, RoutedEventArgs e) //open delete recipe window
        {
            if (deleteRecipeWindow == null || !deleteRecipeWindow.IsLoaded) // if delete window is not open or loaded it will initialize it
            {
                deleteRecipeWindow = new DeleteRecipeWindow(this, method); //passes main window and method so recipes do no get erased
                deleteRecipeWindow.Show();
                this.Hide(); //hides main window
            }
            else
            {
                searchRecipeWindow.Focus(); //focuses on delete window
            }
        }

        private void ExitApp(object sender, RoutedEventArgs e) //exit application button
        {
            Application.Current.Shutdown(); //shuts down application
        }
    }
}
