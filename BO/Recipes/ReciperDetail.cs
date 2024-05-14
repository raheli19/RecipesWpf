using System.Collections.Generic;

namespace BO
{
    public class ReciperDetail
    {
        public Identification identification { get; set; }
        public Status status { get; set; }
        public string level { get; set; }
        public bool promote { get; set; }
        public Reciperu Reciperu { get; set; }
        public Reciperm Reciperm { get; set; }
        public object owner { get; set; }
        public object airspace { get; set; }
        public Reciperi Reciperi { get; set; }
        public ReciperHistory ReciperHistory { get; set; }
        public object ems { get; set; }
        public List<string> availability { get; set; }
        public Time time { get; set; }
        public List<Trail> trail { get; set; }
        public int firstTimestamp { get; set; }
        public string s { get; set; }
    }
}