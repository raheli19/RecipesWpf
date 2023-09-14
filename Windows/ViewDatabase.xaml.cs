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
            // List<Recipe> datRecipes = bl.GetAllRecipeDetails();  //bl.RecipeDataBase
            DataBaseGrid.Visibility = Visibility.Visible;
            DataBaseGrid.ItemsSource = recipes;
        }
        /*

        public ViewDatabase()
        {
            List<Recipe> recipes = bl.RecipesDataBase;
           // List<Recipe> datRecipes = bl.GetAllRecipeDetails();  //bl.RecipeDataBase
            DataBaseGrid.Visibility = Visibility.Visible;
            DataBaseGrid.ItemsSource = recipes;
        }*/
    }
}
