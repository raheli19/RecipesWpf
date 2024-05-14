using BL;
using BO;
using FlightsMap.ViewModel.Commands;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace FlightsMap.ViewModel
{
    public class MainWinVM: INotifyPropertyChanged
    {

       
        public MainWinVM()
        {
            watchCmd = new OpenWatchC();
            ListOfIngredients = new List<string>();
            
           
        }

        public List<string> ListOfIngredients { get; set; }
       
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public ICommand watchCmd { get; set; }
        public User MyUser { get; set; }
        public MainWindow MW { get; set; }
         BLImp bl = new BLImp();
        
        private ObservableCollection<Pushpin> push=new ObservableCollection<Pushpin>();
    

        private ObservableCollection<Pushpin> origin = new ObservableCollection<Pushpin>();
        public ObservableCollection<Pushpin> Origin
        {
            get
            {
                return origin;
            }
            set
            {
                push = value;
                OnPropertyChanged("Origin");
            }
        }
       


        public object Push { get; private set; }
        void addNewPolyLine(List<Trail> Route)
        {
            MapPolyline polyline = new MapPolyline();
            polyline.Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Purple);
            polyline.StrokeThickness = 3;
            polyline.StrokeDashOffset = 2;
            polyline.StrokeDashArray = new System.Windows.Media.DoubleCollection() { 4, 4 };

            polyline.Locations = new LocationCollection();
            foreach (var item in Route)
            {
                polyline.Locations.Add(new Location(item.lat, item.lng));
            }
        }

       

    }
}
