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
        private void btnComment_click(object sender, RoutedEventArgs e)  
        {
            var my_name = ((Button)sender).Tag.ToString();
            Console.WriteLine(my_name);

            Window1 window = new Window1(my_name);  // Comment window
            window.DataContext = window;
            window.Show();



        }
        //
        private void btnSaveComment_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var recipeId = button.Tag.ToString();
            var updatedComments = ((Recipe)DataBaseGrid.SelectedItem).Comments;

            // Update the comments in your database using your BL or DAL layer
            bl.UpdateCommentRecipe(recipeId, updatedComments);
        }

        private void StarRatingControl_RatingChanged(object sender, int rating)
        {
            if (sender is StarRatingControl starRatingControl)
            {
                if (DataBaseGrid.SelectedItem is Recipe selectedRecipe)
                {
                    // Get the recipe name associated with this row (you need to adjust this part based on your data)
                    string recipeName = selectedRecipe.Title; ;

                    // Call the DAL method to update the rating
                    bl.UpdateRateRecipe(recipeName, rating);
                }
            }
        }


    }
}
