﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class Players
    {
        public int PlayerID { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string YearDrafted { get; set; }
        public bool Active { get; set; }
        public string TeamName { get; set; }
        public string EspnID { get; set; }
    }
}

