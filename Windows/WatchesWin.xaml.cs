using BL;
using BO;
using BO.Recipers;
using Recipes.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using static Recipes.ViewModel.WatchWinVM;


namespace Recipes.Windows
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
            //listView.Visibility = Visibility.Visible;
            //WatchList = new ObservableCollection<Calend>();
        }

        public WatchesWin(User myUser, Calendar calendar)
        {
            InitializeComponent();

            MyUser = myUser;
            this.calendar = calendar;

            // Create an instance of WatchWinVM and set it as DataContext
            DataContext = new WatchWinVM(MyUser, calendar);

            listView.Visibility = Visibility.Visible;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private ObservableCollection<Calend> watchList;
        

        public ObservableCollection<Calend> WatchList
        {
            get
            {
                return watchList;
            }
            set
            {

                watchList = value;
                OnPropertyChanged("WatchList");
            }
        }

        public User MyUser { get; private set; }
        public Calendar calendar { get; private set; }

        private void enter_ingredients_click(object sender, RoutedEventArgs e)
        {
            string id = (SearchByIngTB.Text).ToString();
            List<RecipesSimilar> simRecipes = bl.GetSimilarRecipes(id);
            dataGrid.Visibility = Visibility.Visible;
            dataGrid.ItemsSource = simRecipes;
        }

        private void DateChanged(object sender, RoutedEventArgs e)
        {
            // Get the selected date from the calendar
            DateTime selectedDate = calender.SelectedDate.GetValueOrDefault();

            // Call a method to retrieve the list of recipes for the selected date
            //List<Calend> recipes = bl.GetCalendWatches(selectedDate);
            //WatchList = new ObservableCollection<Calend>(recipes);

            // Bind the list of recipes to the ListView
            //listView.ItemsSource = recipes;
        }
    }
}
