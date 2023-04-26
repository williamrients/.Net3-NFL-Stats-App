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
        public ActionResult Create(Players player)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _playerManager.InsertNewPlayer(player.GivenName, player.FamilyName, player.YearDrafted, player.TeamName);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return View(player);
        }

        // GET: Players/Edit/5
        public ActionResult Edit(int playerID)
        {
            if (playerID == null || playerID == 0)
            {
                return RedirectToAction("Index");
            }

            try
            {
                Players player = _playerManager.GetPlayerByPlayerID(playerID);
                ViewBag.teamsDDL = _teamsDDL;
                return View(player);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: Players/Edit/5
        [HttpPost]
        public ActionResult Edit(int playerID, Players player)
        {
            try
            {
                Players oldPlayer = _playerManager.GetPlayerByPlayerID(playerID);
                _playerManager.EditPlayerTeamByPlayerID(oldPlayer, player);
                return RedirectToAction("Index");                
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(player);
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
