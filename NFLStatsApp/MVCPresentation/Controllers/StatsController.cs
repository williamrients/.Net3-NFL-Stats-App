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
    public class StatsController : Controller
    {
        IPlayerStatManager _statManager = null;
        IPlayerManager _playerManager = null;
        private IEnumerable<String> _statsDDL;
        private IEnumerable<String> _seasonIDsDDL;

        public StatsController()
        {
            _statManager = new PlayerStatManager();
            _playerManager = new PlayerManager();
            try
            {
                _statsDDL = _statManager.RetrieveAllStatNames();
                _seasonIDsDDL = _statManager.RetrieveAllSeasonIDs();
            }
            catch (Exception)
            {
                // direct to error page
                throw;
            }
        }

        // GET: Stats
        public ActionResult Index()
        {
            IEnumerable<Stats> stats = _statManager.GetAllPlayerStatsByActive(true);

            return View(stats);
        }

        // GET: Stats/Details/5
        public ActionResult Details(int? playerID)
        {
            if (playerID == null || playerID == 0)
            {
                return RedirectToAction("Index");
            }
            IEnumerable<Stats> stats = _statManager.GetAllPlayerStatsByPlayerID((int)playerID);

            return View(stats);
        }

        // GET: Stats/Create
        public ActionResult Create(int? playerID)
        {
            if (playerID == null || playerID == 0)
            {
                return RedirectToAction("Index");
            }
            
            try
            {
                PlayerAndStatsModel playerModel = new PlayerAndStatsModel();
                playerModel.player = _playerManager.GetPlayerByPlayerID((int)playerID);
                ViewBag.statNamesDDL = _statsDDL;
                ViewBag.seasonIDsDDL = _seasonIDsDDL;
                return View(playerModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            
        }

        // POST: Stats/Create
        [HttpPost]
        public ActionResult Create(PlayerAndStatsModel playerAndStatsModel)
        {
            try
            {
                playerAndStatsModel.stats.PlayerID = playerAndStatsModel.player.PlayerID;
                playerAndStatsModel.player = _playerManager.GetPlayerByPlayerID(playerAndStatsModel.player.PlayerID);
                if (_statManager.RetrieveStatByPlayerIDSeasonIDAndStatName(playerAndStatsModel.stats))
                {
                    Session["playerStats"] = playerAndStatsModel;
                    Session["editingMessage"] = "Updating Stat for " + playerAndStatsModel.player.GivenName + " " + playerAndStatsModel.player.FamilyName;
                    return RedirectToAction("Edit", new 
                    {
                        playerID = playerAndStatsModel.stats.PlayerID,
                        statName = playerAndStatsModel.stats.StatName,
                        seasonID = playerAndStatsModel.stats.SeasonID
                    });
                }
                else
                {
                    _statManager.InsertNewPlayerStat(playerAndStatsModel.stats);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Stats/Edit/5
        public ActionResult Edit(int playerID, string statName, string seasonID)
        {
            Stats stats = new Stats()
            {
                PlayerID = playerID,
                StatName = statName,
                SeasonID = seasonID
            };
            stats = _statManager.GetStatByPlayerIDSeasonIDAndStatName(stats);
            return View(stats);
        }

        // POST: Stats/Edit/5
        [HttpPost]
        public ActionResult Edit(int playerID, string statName, string seasonID, Stats stats)
        {
            try
            {
                Stats oldStat = new Stats()
                {
                    PlayerID = playerID,
                    StatName = statName,
                    SeasonID = seasonID
                };
                oldStat = _statManager.GetStatByPlayerIDSeasonIDAndStatName(oldStat);
                _statManager.EditStatByPlayerIDSeasonIDAndStatName(oldStat, stats);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }
    }
}
