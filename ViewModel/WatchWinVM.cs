using BL;
using BO;
using Recipes.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace Recipes.ViewModel
{
    public class WatchWinVM : INotifyPropertyChanged
    {
        public WatchWinVM(User u,Calendar c)
        {
            MyUser = u;        
            calendar = c;
            c.SelectedDatesChanged += DateChangedEvent;
            if(c.SelectedDates.Count==0)
            {
                c.SelectedDates.Add(DateTime.Today);
            }
            //ClockSign(2);
            
            
        }
        
        public User MyUser { get; set; }
        public Calendar calendar { get; set; }
        BLImp bl = new BLImp();
        private ObservableCollection<Calend> watchList;


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); //PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }



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


        private void DateChangedEvent(object sender, SelectionChangedEventArgs e)
        {
            // Get the selected date from the calendar
            if (e.AddedItems.Count > 0 && e.AddedItems[0] is DateTime selectedDate)
            {
                // Call a method to retrieve the list of Calend for the selected date
                List<Calend> recipes = bl.GetCalendWatches(selectedDate);
                WatchList = new ObservableCollection<Calend>(recipes);
            }
        }


        private void DateChanged()                                                       
        {

            if (calendar.SelectedDate.HasValue)
            {
                DateTime selectedDate = calendar.SelectedDate.Value;
                
            }

        }


        //public ObservableCollection<Watch> WatchList
        //{
        //    get
        //    {
        //        return watchList;
        //    }
        //    set
        //    {

        //        watchList = value;
        //        OnPropertyChanged("WatchList");
        //    }
        //}

        //private void DateChangedEvent(object sender, RoutedEventArgs e)
        //{
        //    DateTime start = calendar.SelectedDates.First();
        //    DateTime end = calendar.SelectedDates.Last().AddHours(23.99999);
        //    WatchList= new ObservableCollection<Calend>(bl.GetUserWatches(MyUser.UserId, start, end));
        //}

        //private void DateChanged()
        //{
        //    if (calendar.SelectedDates.Count > 0)
        //    {
        //        DateTime start = calendar.SelectedDates.First();
        //        DateTime end = calendar.SelectedDates.Last().AddHours(23.99999);
        //        WatchList = new ObservableCollection<Watch>(bl.GetUserWatches(MyUser.UserId, start, end));
        //    }
        //}


        //private void ClockSign(int seconds)
        //{
        //    DispatcherTimer timer = new DispatcherTimer();
        //    timer.Tick += (s, e) => DateChanged();
        //    timer.Interval = new TimeSpan(0, 0, seconds);
        //    timer.Start();
        //}


        //private void DateChangedEvent(object sender, RoutedEventArgs e)                       //// 
        //{
        //    DateTime start = calendar.SelectedDates.First();
        //    //DateTime end = calendar.SelectedDates.Last().AddHours(23.99999);
        //    WatchList = new ObservableCollection<Calend>(bl.GetCalendWatches(start));
        //}

    }
}
