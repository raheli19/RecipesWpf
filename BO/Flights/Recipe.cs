using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO.Flights;

namespace BO
{
    public class Recipe
    {
        public int StarRating { get; set; }
        public string Comments { get; set; }
        public string Date { get; set; }
        public List<Ingredient> extendedIngredients { get; set; }

    }
}
