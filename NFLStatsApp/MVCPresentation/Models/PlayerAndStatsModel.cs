using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataObjects;

namespace MVCPresentation.Models
{
    public class PlayerAndStatsModel
    {
        public Players player { get; set; }
        public Stats stats { get; set; }
    }
}