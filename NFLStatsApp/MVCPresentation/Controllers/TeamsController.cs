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
        private ITeamsManager _teamManger = null;        
        private IEnumerable<Teams> allTeams;
        private Teams oldTeam;
        private Teams team;

        public TeamsController()
        {
            _teamManger = new TeamManager();
        }

        // GET: Teams
        public ViewResult Index()
        {
            try
            {
                allTeams = _teamManger.GetAllTeamsByActive(true);
                return View(allTeams);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error retrieving teams\n" + ex.Message;
                return View("Error");
            }
        }

        // GET: Teams/Details/5
        public ActionResult Details(string teamName)
        {
            if (teamName != null && teamName != "")
            {
                try
                {
                    team = _teamManger.RetrieveTeamByTeamName(teamName);
                    if (team.TeamName != null)
                    {
                        return View(team);
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "Error retrieving team\n" + ex.Message;
                    return View("Error");
                }
            }
            return RedirectToAction("Index");
        }

        // GET: Teams/Edit/5
        [Authorize(Roles = "Admin, Administrator, StatAdjuster")]
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
                    oldTeam = _teamManger.RetrieveTeamByTeamName(teamName);
                    _teamManger.UpdateTeam(oldTeam, team);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "Error editing team\n" + ex.Message;
                    return View("Error");
                }
            }
            else
            {
                return View(team);
            }
        }
    }
}
