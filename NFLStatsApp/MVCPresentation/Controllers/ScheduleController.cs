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

        // GET: Schedule/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Schedule/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Schedule/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Schedule/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Schedule/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Schedule/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Schedule/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
