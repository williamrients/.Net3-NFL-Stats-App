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
        private IPlayerManager _playerManager = null;
        private ITeamsManager _teamManager = null;
        private IEnumerable<Players> allPlayers;
        private IEnumerable<Players> playerList;
        private IEnumerable<String> _teamsDDL;

        public PlayersController()
        {
            _playerManager = new PlayerManager();
            _teamManager = new TeamManager();
            try
            {
                _teamsDDL = _teamManager.RetrieveAllTeamNames();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                Redirect("Error");
            }
        }

        // GET: Players
        public ActionResult Index()
        {
            try
            {
                allPlayers = _playerManager.GetAllPlayersByActive(true);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error retrieving players\n" + ex.Message;
                return View("Error");
            }
            return View(allPlayers); 
        }

        // GET: Players/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Players/Create
        [Authorize(Roles = "Admin, Administrator, StatAdjuster")]
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
                    ViewBag.ErrorMessage = "Error creating a new player\n" + ex.Message;
                    return View("Error");
                }
            }
            return View(player);
        }

        // GET: Players/Edit/5
        [Authorize(Roles = "Admin, Administrator, StatAdjuster")]
        public ActionResult Edit(int? playerID)
        {
            if (playerID == null || playerID == 0)
            {
                return RedirectToAction("Index");
            }

            try
            {
                Players player = _playerManager.GetPlayerByPlayerID((int)playerID);
                ViewBag.teamsDDL = _teamsDDL;
                return View(player);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error retrieving player with that ID\n" + ex.Message;
                return View("Error");
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
                ViewBag.ErrorMessage = "Error editing player\n" + ex.Message;
                return View("Error");
            }
        }

        // GET: Players By Team
        [Authorize]
        public ActionResult PlayersOnTeam(string teamName)
        {
            
            if (teamName != null && teamName != "")
            {
                try
                {
                    playerList = _playerManager.GetAllPlayersByTeamName(teamName);
                    return View(playerList);
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "Error retrieving players on that team\n" + ex.Message;
                    return View("Error");
                }
            }
            return RedirectToAction("Index", "Teams");
        }

    }
}
