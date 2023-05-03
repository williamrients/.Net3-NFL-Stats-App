using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayerInterfaces
{
    public interface IScheduleManager
    {
        List<Schedule> RetrieveScheduleBySeasonIDAndWeekNumber(string seasonID, int weekNumber);
        List<int> RetrieveDistinctWeeks();
    }
}
