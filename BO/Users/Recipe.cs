using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int StarRating { get; set; }
        public string Comments { get; set; }
        public string Dates { get; set; }
    }
}
