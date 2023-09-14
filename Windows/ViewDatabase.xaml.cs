using BL;
using BO;
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
using System.Windows.Shapes;

namespace Recipes.Windows
{
    /// <summary>
    /// Interaction logic for ViewDatabase.xaml
    /// </summary>
    public partial class ViewDatabase : Window
    {
        BLImp bl = new BLImp();
        public ViewDatabase()
        {
            InitializeComponent();
            List<Recipe> recipes = bl.getRecipesDB();
            DataBaseGrid.Visibility = Visibility.Visible;
            DataBaseGrid.ItemsSource = recipes;
        }

        //
       /* private void enter(object sender, RoutedEventArgs e)  
        {
            string recipeId = ((Button)sender).Tag.ToString();





            


            var my_name = ((Button)sender).Tag.ToString();
            Console.WriteLine(my_name);

            Window1 window = new Window1(my_name);  // Comment window
            window.DataContext = window;
            window.Show();



        }*/
        //
        /*
        private void btnSaveComment_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var recipeId = button.Tag.ToString();
            var updatedComments = ((Recipe)DataBaseGrid.SelectedItem).Comments;

            // Update the comments in your database using your BL or DAL layer
            bl.UpdateCommentRecipe(recipeId, updatedComments);
        }

        */
        private void enter_comment(object sender, RoutedEventArgs e)
        {
            string recipeId = ((Button)sender).Tag.ToString();
            Console.WriteLine("AAAAAAAAAAAAAAA");
        }
    }
}
