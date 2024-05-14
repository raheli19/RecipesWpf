﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Recipers
{
    public class ReciperInfoPartial
    {
        public int Id { get; set; }
        public string SourceId { get; set; }
        public double Long { get; set; }
        public double Lat { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string ReciperCode { get; set; }
    }
}
