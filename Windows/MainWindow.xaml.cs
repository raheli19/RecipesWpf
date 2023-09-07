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
            dataGrid.ItemsSource = listIng;
            dataGrid.Columns.RemoveAt(3);
           // dataGrid.Columns.Add((new DataGridColumn).SetValue((new Image).Source= "https://spoonacular.com/recipeImages/633126-312x231.jpg"));

        }

    
    }
}
