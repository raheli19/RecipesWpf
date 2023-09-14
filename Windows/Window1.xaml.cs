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

namespace Recipes.Windows
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        BLImp bl = new BLImp();

        public string Comment
        {
            get { return commentBlock.Text; }
            set { commentBlock.Text = value; }
        }

        public string RecipeName { get; private set; }

        public Window1(string name)
        {
            InitializeComponent();
            CommentGrid.Visibility = Visibility.Visible;
            RecipeName = name;
        }


        private void enter_comment_click(object sender, RoutedEventArgs e)
        {
            string comment = (commentBlock.Text).ToString();
            Console.WriteLine(comment);
            string recipeName = RecipeName;
            bl.UpdateCommentRecipe(recipeName, comment);
            this.Close();
        }
    }
}
