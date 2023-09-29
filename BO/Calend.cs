using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Calend
    {
        public DateTime Date { get; set; }
        public string Recipe { get; set; }
        public string HolidayName { get; set; }
    }
}
