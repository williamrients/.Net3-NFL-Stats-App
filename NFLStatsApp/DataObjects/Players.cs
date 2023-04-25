using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataObjects
{
    public class Players
    {
        public int PlayerID { get; set; }
        [Required]
        public string GivenName { get; set; }
        [Required]
        public string FamilyName { get; set; }
        [Required]
        public string YearDrafted { get; set; }
        public bool Active { get; set; }
        [Required]
        public string TeamName { get; set; }
        public string EspnID { get; set; }
    }
}

