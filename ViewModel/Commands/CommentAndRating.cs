using BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Recipes.ViewModel.Commands
{
    class CommentAndRating : INotifyPropertyChanged
    {
        BLImp bl = new BLImp();

        private string comments;

        public string Comments
        {
            get { return comments; }
            set
            {
                comments = value;
                OnPropertyChanged(nameof(Comments));
            }
        }


        private int selectedRating;

        public int SelectedRating
        {
            get { return selectedRating; }
            set
            {
                selectedRating = value;
                OnPropertyChanged(nameof(SelectedRating));
            }
        }

        // Populate the Ratings property with numbers 1 to 5
        public List<int> Ratings { get; } = Enumerable.Range(1, 5).ToList();

        // Implement INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
