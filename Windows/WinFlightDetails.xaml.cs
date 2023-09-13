using BL;
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

namespace FlightsMap.Windows
{
    /// <summary>
    /// Logique d'interaction pour WinFlightDetails.xaml
    /// </summary>
    public partial class WinFlightDetails : Window
    {
        BLImp bl = new BLImp();
        public WinFlightDetails()
        {
            InitializeComponent();

        }
        public WinFlightDetails(string id,string link)
        {
            
            InitializeComponent();
            string steps = bl.AnalyzedRecipeInstructions(id);
            //label.Content = steps;
            //List<string> stepsList = steps.Split('\n').ToList<string>();
            textBlock.Text= steps;
            //dataGrid.ItemsSource = steps;
            var converter = new ImageSourceConverter();
            background.Source = (ImageSource)converter.ConvertFromString(link);
            

        }

        private void close_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
