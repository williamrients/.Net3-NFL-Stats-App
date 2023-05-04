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

        public bool CreateNewGame(Schedule schedule)
        {
            bool success = false;

            try
            {
                if (1 == _scheduleAccessor.InsertNewGame(schedule))
                {
                    success = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return success;
        }

        public List<int> RetrieveDistinctWeeks()
        {
            List<int> weekList = null;

            try
            {
                weekList = _scheduleAccessor.SelectDistinctWeeks();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return weekList;
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
