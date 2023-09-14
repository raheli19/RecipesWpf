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
        }

        public ViewDatabase(string my_id)
        {
            List<Recipe> datRecipes = bl.GetAllRecipeDetails(my_id);  //bl.RecipeDataBase
            DataBaseGrid.Visibility = Visibility.Visible;
            DataBaseGrid.ItemsSource = datRecipes;
        }
    }
}
