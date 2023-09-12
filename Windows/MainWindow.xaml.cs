using BL;
using BO;
using BO.Flights;
using FlightsMap.ViewModel;
using FlightsMap.ViewModel.Commands;
using FlightsMap.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;





namespace FlightsMap
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal object myMap;
       BLImp bl = new BLImp();
       // MainWinVM vm = new MainWinVM();

        public MainWindow()
        {
            InitializeComponent();          
            
        }



        private void enter_ingredients_click(object sender, RoutedEventArgs e)
        {
            List<string> listOfIng = (SearchByIngTB.Text).Split(',').ToList<string>();
            Console.WriteLine(listOfIng);
            List<RecipeInfoPartial> listIng = bl.SearchByIngredients(listOfIng);
            string id = "656663";
            string lst = bl.AnalyzedRecipeInstructions(id);
            dataGridKW.Visibility = Visibility.Hidden;
            dataGrid.Visibility = Visibility.Visible;
            dataGrid.ItemsSource = listIng;
            dataGrid.Columns.RemoveAt(3);
           // dataGrid.Columns.Add((new DataGridColumn).SetValue((new Image).Source= "https://spoonacular.com/recipeImages/633126-312x231.jpg"));

        }

        private void enter_KW_Click(object sender, RoutedEventArgs e)
        {
            string keyWord = (SearchByKW.Text);
            Console.WriteLine(keyWord);
            List<RecipeKeyWord> listIng = bl.SearchByKeyWord(keyWord);
            dataGrid.Visibility = Visibility.Hidden;
            dataGridKW.Visibility = Visibility.Visible;
            dataGridKW.ItemsSource = listIng;
            dataGridKW.Columns.RemoveAt(3);
        }

        private void btnGrid_click(object sender, RoutedEventArgs e)
        {
            var my_id = ((Button)sender).Tag.ToString();
            Console.WriteLine(my_id);
            var my_link= ((Button)sender).CommandParameter.ToString();
            WinFlightDetails window = new WinFlightDetails(my_id,my_link);
            window.Show();
        }



    }
}
