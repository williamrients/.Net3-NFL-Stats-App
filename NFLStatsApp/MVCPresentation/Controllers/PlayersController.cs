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
    public class PlayersController : Controller
    {
        IPlayerManager _playerManager = null;
        ITeamsManager _teamManager = null;
        private IEnumerable<String> _teamsDDL;

        public PlayersController()
        {
            _playerManager = new PlayerManager();
            _teamManager = new TeamManager();
            try
            {
                _teamsDDL = _teamManager.RetrieveAllTeamNames();
            }
            catch (Exception)
            {
                // direct to error page
                throw;
            }
        }

        // GET: Players
        public ActionResult Index()
        {
            IEnumerable<Players> allPlayers = _playerManager.GetAllPlayersByActive(true);

            return View(allPlayers); 
        }

        // GET: Players/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Players/Create
        public ActionResult Create()
        {
            ViewBag.teamsDDL = _teamsDDL;
            return View();
        }

        // POST: Players/Create
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

        // GET: Players/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Players/Edit/5
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

        // GET: Players By Team
        public ActionResult PlayersOnTeam(string teamName)
        {
            if (teamName == null)
            {
                RedirectToAction("Index");
            }

            IEnumerable<Players> playerList = _playerManager.GetAllPlayersByTeamName(teamName); 

            return View(playerList); 
        }

    }
}
