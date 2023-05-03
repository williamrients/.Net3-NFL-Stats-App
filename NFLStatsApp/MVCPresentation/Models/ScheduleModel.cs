using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataObjects;
using System.ComponentModel.DataAnnotations;

namespace MVCPresentation.Models
{
    public class ScheduleModel
    {
        public IEnumerable<Schedule> schedules{ get; set; }
        public string SeasonID { get; set; }
        public int WeekNumberOption { get; set; }
    }

}