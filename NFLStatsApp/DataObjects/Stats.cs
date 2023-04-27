using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataObjects
{
    public class Stats
    {
        [Required]
        public int PlayerID { get; set; }
        [Required]
        public string GivenName { get; set; }
        [Required]
        public string FamilyName { get; set; }
        [Required]
        public string StatName { get; set; }
        [Required]
        [Range(1, 1000)]
        public double StatAmount { get; set; }
        public bool Active { get; set; }
        [Required]
        public string SeasonID { get; set; }
    }
}