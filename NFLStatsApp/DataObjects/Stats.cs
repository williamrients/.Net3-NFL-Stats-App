using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class Stats
    {
        public int PlayerID { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string StatName { get; set; }
        public double StatAmount { get; set; }
        public bool Active { get; set; }
        public string SeasonID { get; set; }
    }
}