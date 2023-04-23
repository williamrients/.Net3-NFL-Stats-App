using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataObjects;
using LogicLayerInterfaces;
using LogicLayer;

namespace MVCPresentation.Controllers
{
    public class TeamsController : Controller
    {
        ITeamsManager _teamManger = null;

        public TeamsController()
        {
            _teamManger = new TeamManager();
        }

        public TeamsController(ITeamsManager teamsManager)
        {
            _teamManger = teamsManager;
        }

        // GET: Teams
        public ViewResult Index()
        {
            IEnumerable<Teams> allTeams = _teamManger.GetAllTeamsByActive(true);

            return View(allTeams);
        }

        // GET: Teams/Details/5
        public ActionResult Details(string teamName)
        {
            if (teamName == null)
            {
                return RedirectToAction("Index");
            }
            Teams teams = _teamManger.RetrieveTeamByTeamName(teamName);

            return View(teams);
        }

        // GET: Teams/Edit/5
        public ActionResult Edit(string teamName)
        {
            if (teamName == null)
            {
                return RedirectToAction("Index");
            }
            

            return View();
        }

        // POST: Teams/Edit/5
        [HttpPost]
        public ActionResult Edit(string teamName, Teams team)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Teams oldTeam = _teamManger.RetrieveTeamByTeamName(teamName);
                    _teamManger.UpdateTeam(oldTeam, team);

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return View();
                }
            }
            else
            {
                return View(team);
            }
        }

        // GET: Teams/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Teams/Delete/5
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
