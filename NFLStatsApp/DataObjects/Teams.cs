using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataObjects
{
    public class Teams
    {
        public string TeamName { get; set; }
        [Required]
        public string TeamMascot { get; set; }
        [Required]
        public string TeamCity { get; set; }
        [Required]
        public string TeamState { get; set; }
        public string TeamAbbrivation { get; set; }
        public bool Active { get; set; }
    }
}
