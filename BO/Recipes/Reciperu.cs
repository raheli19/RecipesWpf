using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Reciperu
    {
        public Model model { get; set; }
        public int countryId { get; set; }
        public string registration { get; set; }
        public string hex { get; set; }
        public object age { get; set; }
        public object msn { get; set; }
        public Images images { get; set; }
        public Identification identification { get; set; }
        public Reciperi Reciperi { get; set; }
        public Time time { get; set; }
    }
}
