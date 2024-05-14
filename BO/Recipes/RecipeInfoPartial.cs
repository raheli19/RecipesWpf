using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Recipers
{
    public class RecipeInfoPartial
        
    {
       
        public string Id { get; set; }
        public string Title { get; set; }
        public string ImageLink { get; set; }
        public int UsedIngredientsCount { get; set; }
        public int MissedIngredientsCount { get; set; }
        public string UsedIngredients { get; set; }
        public string MissedIngredients { get; set; }



    }
}
