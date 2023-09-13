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
        public string Id { get; set; }
        public string Aisle { get; set; }
        public string ImageLink { get; set; }
        public string Name { get; set; }
        public int StarRating { get; set; }
        public string Comments { get; set; }
        public string Date { get; set; }
    }
}
