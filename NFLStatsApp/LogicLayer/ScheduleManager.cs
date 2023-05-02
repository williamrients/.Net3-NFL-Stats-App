using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessLayerInterfaces;
using LogicLayerInterfaces;

namespace LogicLayer
{
    public class ScheduleManager : IScheduleManager
    {
        private IScheduleAccessor _scheduleAccessor = null;

        public ScheduleManager()
        {
            _scheduleAccessor = new DataAccessLayer.ScheduleAccessor();
        }

        public ScheduleManager(IScheduleAccessor scheduleAccessor)
        {
            _scheduleAccessor = scheduleAccessor;
        }

        public List<Schedule> RetrieveScheduleBySeasonIDAndWeekNumber(string seasonID, int weekNumber)
        {
            List<Schedule> scheduleList = null;

            try
            {
                scheduleList = _scheduleAccessor.SelectScheduleBySeasonIDAndWeekNumber(seasonID, weekNumber);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return scheduleList;
        }
    }
}
