using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO.Recipers;

namespace BO
{
    public class Recipe
    {
        public string RId { get; set; }
        public string Title { get; set; }
        public string ReadyInMinutes { get; set; }
        public string Servings { get; set; }
        public string Summary { get; set; }
        public string Image { get; set; }
        public string Instructions { get; set; }
        public int StarRating { get; set; }
        public string Comments { get; set; }
        public string Date { get; set; }
        public string extendedIngredientsString { get; set; }
        public List<Ingredient> extendedIngredients { get; set; }

    }
}
