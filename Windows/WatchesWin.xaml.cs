using BL;
using BO;
using BO.Flights;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace FlightsMap.Windows
{
    /// <summary>
    /// Interaction logic for WatchesWin.xaml
    /// </summary>
    public partial class WatchesWin : Window
    {

        BLImp bl = new BLImp();

        public WatchesWin()
        {
            InitializeComponent();        
        }
       
        

        private void enter_ingredients_click(object sender, RoutedEventArgs e)
        {
            string id = (SearchByIngTB.Text).ToString();
            List<RecipesSimilar> simRecipes = bl.GetSimilarRecipes(id);
            dataGrid.Visibility = Visibility.Visible;
            dataGrid.ItemsSource = simRecipes;
        }
    }
}
