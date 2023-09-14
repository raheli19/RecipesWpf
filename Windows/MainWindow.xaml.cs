using BL;
using BO;
using BO.Flights;
using FlightsMap.ViewModel;
using FlightsMap.ViewModel.Commands;
using FlightsMap.Windows;
using Recipes.Windows;
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
        }

        private void btnGrid_click(object sender, RoutedEventArgs e)  //quand on clique sur le bouton step
        {
            var my_id = ((Button)sender).Tag.ToString();
            Console.WriteLine(my_id);
            var my_link= ((Button)sender).CommandParameter.ToString();
            WinFlightDetails window = new WinFlightDetails(my_id,my_link);

            //il faut faire une fonction dans la dal (api) qui recoit un id et renvoit les données.
            //Tu envoie le id et recois en retour une liste de recette (creer une class Recipe avec ttes les infos)
            //Ajouter pr chaque recette une date random
            //renvoyer la liste dans la dal
            //dans la nouvelle fenetre qui souvrira quand on appuie sur view database, on affiche un grid avec cette liste
            //jajoute a la fin de chaque ligne du grid un bouton getSimilarRecipe et je lie avec le api créé dans la DAL

            List<Recipe> recipeDetails = bl.GetAllRecipeDetails(my_id);
            if (recipeDetails != null && recipeDetails.Count > 0)
            {
                foreach (var recipe in recipeDetails)
                {
                    // Check if the recipe with the same ID already exists in your list, and update it if necessary
                    var existingRecipe = bl.RecipesDataBase.FirstOrDefault(r => r.Title == recipe.Title);
                    if (existingRecipe != null)
                    {
                        // Update existing recipe with new details
                        existingRecipe.StarRating = recipe.StarRating;
                        existingRecipe.Comments = recipe.Comments;
                        existingRecipe.Date = recipe.Date;
                    }
                    else
                    {
                        // Add the new recipe to your list
                        bl.RecipesDataBase.Add(recipe);
                    }
                }

                // Optional: Refresh your UI to reflect the updated or added recipes
                // For example, if you're using a DataGridView to display recipes:
                // dataGridView.DataSource = null;
                // dataGridView.DataSource = recipesDatabase;

                // Optionally display a message to indicate that the recipe has been saved
                MessageBox.Show("Recipe saved successfully!");
            }
            else
            {
                // Handle the case where the recipe details could not be retrieved
                MessageBox.Show("Failed to retrieve recipe details.");
            }
            window.Show();

        }

        private void viewDatabase_Click(object sender, RoutedEventArgs e)
        {
            ViewDatabase window = new ViewDatabase();
            window.Show();
        }
    }
}
