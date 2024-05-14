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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Recipes
{
    /// <summary>
    /// Interaction logic for StarRatingControl.xaml
    /// </summary>
    public partial class StarRatingControl : UserControl
    {
        public event EventHandler<int> RatingChanged;
        BLImp bl = new BLImp();

        public StarRatingControl()
        {
            InitializeComponent();
            Unloaded += StarRatingControl_Unloaded;
        }


        private void StarRatingControl_Unloaded(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("O");
            if (sender is Button button && int.TryParse(button.Tag.ToString(), out int rating))
            {
                var r = button.DataContext as Recipe;
                string recipeName = r.Title;
                SaveRating (recipeName, rating); // Save the rating when the control is unloaded
            }
            
        }


        private void Star_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("PO");

            if (sender is Button button && int.TryParse(button.Tag.ToString(), out int rating))
            {
                var r = button.DataContext as Recipe;
                string recipeName = r.Title;
                SetRating(recipeName, rating);
            }
        }

        public void SetRating(string recipeName, int rating)
        {

            foreach (UIElement child in (Content as StackPanel).Children)
            {
                if (child is Button button)
                {
                    int tag = int.Parse(button.Tag.ToString());
                    var textBlock = button.Template.FindName("StarText", button) as TextBlock;
                    if (textBlock != null)
                    {
                        textBlock.Text = tag <= rating ? "★" : "☆";
                        textBlock.Foreground = tag <= rating ? Brushes.Gold : Brushes.Gray; // Change star color

                    }
                    if (tag == rating) // Only update the rating for the clicked star
                    {
                        Console.WriteLine(rating);
                        Console.WriteLine(recipeName);
                        Console.WriteLine("TO");


                        // Update the rating in the database
                        bl.UpdateRateRecipe(recipeName, rating);
                    }
                }
            }

            RatingChanged?.Invoke(this, rating);
        }


        private void SaveRating(string recipeName, int rating)
        {
            Console.WriteLine("LO");

            bl.UpdateRateRecipe(recipeName, rating);
        }
    }
}
