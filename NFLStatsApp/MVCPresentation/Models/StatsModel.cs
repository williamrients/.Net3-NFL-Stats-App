using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataObjects;

namespace MVCPresentation.Models
{
    public class StatsModel
    {
        public IEnumerable<Stats> Stats{ get; set; }
        public string StatName { get; set; }
    }
}