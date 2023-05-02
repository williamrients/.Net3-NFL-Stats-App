using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayerInterfaces
{
    public interface IScheduleAccessor
    {
        List<Schedule> SelectScheduleBySeasonIDAndWeekNumber(string seasonID, int weekNumber);
    }
}
