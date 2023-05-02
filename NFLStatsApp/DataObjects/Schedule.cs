using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class Schedule
    {
        public int GameID { get; set; }
        public string TeamNameAway { get; set; }
        public string TeamNameHome { get; set; }
        public int TeamAwayScore { get; set; }
        public int TeamHomeScore { get; set; }
        public int WeekNumber { get; set; }
        public string SeasonID { get; set; }
        public bool OverTime { get; set; }
        public DateTime GameDate { get; set; }
    }
}
