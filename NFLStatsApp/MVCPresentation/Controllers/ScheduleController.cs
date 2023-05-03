using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataObjects;
using LogicLayerInterfaces;
using LogicLayer;
using MVCPresentation.Models;

namespace MVCPresentation.Controllers
{
    public class ScheduleController : Controller
    {
        private IScheduleManager _scheduleManager = null;
        private IPlayerStatManager _statManager = null;
        private IEnumerable<Schedule> scheduleList;
        private ScheduleModel scheduleModel = new ScheduleModel();
        private IEnumerable<String> _seasonIDsDDL;
        private IEnumerable<int> _weeksDDL;

        public ScheduleController()
        {
            _scheduleManager = new ScheduleManager();
            _statManager = new PlayerStatManager();

            try
            {
                _seasonIDsDDL = _statManager.RetrieveAllSeasonIDs();
                _weeksDDL = _scheduleManager.RetrieveDistinctWeeks();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Schedule
        public ActionResult Index(ScheduleModel scheduleModel)
        {
            try
            {
                if (scheduleModel.SeasonID == null)
                {
                    scheduleModel.SeasonID = _seasonIDsDDL.First();
                    scheduleModel.WeekNumberOption = _weeksDDL.First();
                    scheduleList = _scheduleManager.RetrieveScheduleBySeasonIDAndWeekNumber(scheduleModel.SeasonID, scheduleModel.WeekNumberOption);
                }
                else
                {
                    scheduleList = _scheduleManager.RetrieveScheduleBySeasonIDAndWeekNumber(scheduleModel.SeasonID, (int)scheduleModel.WeekNumberOption);                    
                }
                teamAbr(scheduleList);
                scheduleModel.schedules = scheduleList;

                

                ViewBag.SeasonDDL = _seasonIDsDDL;
                ViewBag.WeekDDL = _weeksDDL;
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error retrieving schedule\n" + ex.Message;
                return View("Error");
            }
            return View(scheduleModel);
        }

        //Helper method for team abbreviations
        public void teamAbr(IEnumerable<Schedule> schedule)
        {
            foreach (Schedule item in schedule)
            {
                switch (item.TeamNameAway)
                {
                    case "Cardinals":
                        item.TeamAwayAbr = "ARI";
                        break;
                    case "Rams":
                        item.TeamAwayAbr = "LAR";
                        break;
                    case "Chargers":
                        item.TeamAwayAbr = "LAC";
                        break;
                    case "49ers":
                        item.TeamAwayAbr = "SF";
                        break;
                    case "Broncos":
                        item.TeamAwayAbr = "DEN";
                        break;
                    case "Jaguars":
                        item.TeamAwayAbr = "JAX";
                        break;
                    case "Dolphins":
                        item.TeamAwayAbr = "MIA";
                        break;
                    case "Buccaneers":
                        item.TeamAwayAbr = "TB";
                        break;
                    case "Falcons":
                        item.TeamAwayAbr = "ATL";
                        break;
                    case "Bears":
                        item.TeamAwayAbr = "CHI";
                        break;
                    case "Colts":
                        item.TeamAwayAbr = "IND";
                        break;
                    case "Saints":
                        item.TeamAwayAbr = "NO";
                        break;
                    case "Ravens":
                        item.TeamAwayAbr = "BAL";
                        break;
                    case "Commanders":
                        item.TeamAwayAbr = "WAS";
                        break;
                    case "Patriots":
                        item.TeamAwayAbr = "NE";
                        break;
                    case "Lions":
                        item.TeamAwayAbr = "DET";
                        break;
                    case "Vikings":
                        item.TeamAwayAbr = "MIN";
                        break;
                    case "Chiefs":
                        item.TeamAwayAbr = "KC";
                        break;
                    case "Raiders":
                        item.TeamAwayAbr = "LV";
                        break;
                    case "Giants":
                        item.TeamAwayAbr = "NYG";
                        break;
                    case "Jets":
                        item.TeamAwayAbr = "NYJ";
                        break;
                    case "Bills":
                        item.TeamAwayAbr = "BUF";
                        break;
                    case "Panthers":
                        item.TeamAwayAbr = "CAR";
                        break;
                    case "Bengals":
                        item.TeamAwayAbr = "CIN";
                        break;
                    case "Browns":
                        item.TeamAwayAbr = "CLE";
                        break;
                    case "Eagles":
                        item.TeamAwayAbr = "PHI";
                        break;
                    case "Steelers":
                        item.TeamAwayAbr = "PIT";
                        break;
                    case "Titans":
                        item.TeamAwayAbr = "TEN";
                        break;
                    case "Cowboys":
                        item.TeamAwayAbr = "DAL";
                        break;
                    case "Texans":
                        item.TeamAwayAbr = "HOU";
                        break;
                    case "Seahawks":
                        item.TeamAwayAbr = "SEA";
                        break;
                    case "Packers":
                        item.TeamAwayAbr = "GB";
                        break;
                    default:
                        item.TeamAwayAbr = "Unknown";
                        break;
                }
            }


            foreach (Schedule item in schedule)
            {
                switch (item.TeamNameHome)
                {
                    case "Cardinals":
                        item.TeamHomeAbr = "ARI";
                        break;
                    case "Rams":
                        item.TeamHomeAbr = "LAR";
                        break;
                    case "Chargers":
                        item.TeamHomeAbr = "LAC";
                        break;
                    case "49ers":
                        item.TeamHomeAbr = "SF";
                        break;
                    case "Broncos":
                        item.TeamHomeAbr = "DEN";
                        break;
                    case "Jaguars":
                        item.TeamHomeAbr = "JAX";
                        break;
                    case "Dolphins":
                        item.TeamHomeAbr = "MIA";
                        break;
                    case "Buccaneers":
                        item.TeamHomeAbr = "TB";
                        break;
                    case "Falcons":
                        item.TeamHomeAbr = "ATL";
                        break;
                    case "Bears":
                        item.TeamHomeAbr = "CHI";
                        break;
                    case "Colts":
                        item.TeamHomeAbr = "IND";
                        break;
                    case "Saints":
                        item.TeamHomeAbr = "NO";
                        break;
                    case "Ravens":
                        item.TeamHomeAbr = "BAL";
                        break;
                    case "Commanders":
                        item.TeamHomeAbr = "WAS";
                        break;
                    case "Patriots":
                        item.TeamHomeAbr = "NE";
                        break;
                    case "Lions":
                        item.TeamHomeAbr = "DET";
                        break;
                    case "Vikings":
                        item.TeamHomeAbr = "MIN";
                        break;
                    case "Chiefs":
                        item.TeamHomeAbr = "KC";
                        break;
                    case "Raiders":
                        item.TeamHomeAbr = "LV";
                        break;
                    case "Giants":
                        item.TeamHomeAbr = "NYG";
                        break;
                    case "Jets":
                        item.TeamHomeAbr = "NYJ";
                        break;
                    case "Bills":
                        item.TeamHomeAbr = "BUF";
                        break;
                    case "Panthers":
                        item.TeamHomeAbr = "CAR";
                        break;
                    case "Bengals":
                        item.TeamHomeAbr = "CIN";
                        break;
                    case "Browns":
                        item.TeamHomeAbr = "CLE";
                        break;
                    case "Eagles":
                        item.TeamHomeAbr = "PHI";
                        break;
                    case "Steelers":
                        item.TeamHomeAbr = "PIT";
                        break;
                    case "Titans":
                        item.TeamHomeAbr = "TEN";
                        break;
                    case "Cowboys":
                        item.TeamHomeAbr = "DAL";
                        break;
                    case "Texans":
                        item.TeamHomeAbr = "HOU";
                        break;
                    case "Seahawks":
                        item.TeamHomeAbr = "SEA";
                        break;
                    case "Packers":
                        item.TeamHomeAbr = "GB";
                        break;
                    default:
                        item.TeamHomeAbr = "Unknown";
                        break;
                }
            }
        }
    }
}
