﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCPresentation.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace MVCPresentation.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUserManager userManager;

        // GET: Admin
        public ActionResult Index()
        {
            //return View(db.ApplicationUsers.ToList());
            userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            return View(userManager.Users.OrderBy(n => n.FamilyName).ToList());
        }

        //GET: Admin/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //ApplicationUser applicationUser = db.ApplicationUsers.Find(id);
            userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationUser applicationUser = userManager.FindById(id);

            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            // get a list of roles the user has and put them into a viewbag as roles
            // along with a list of roles the user doesn't have as noRoles
            var usrMrg = new LogicLayer.Usermanager();
            var allRoles = usrMrg.RetrievAllRoles();

            var roles = userManager.GetRoles(id);
            var noRoles = allRoles.Except(roles);

            ViewBag.Roles = roles;
            ViewBag.NoRoles = noRoles;

            return View(applicationUser);
        }

        public ActionResult RemoveRole(string id, string role)
        {
            var userManger = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManger.Users.First(u => u.Id == id);

            // code to prevent removing the last administrator
            if (role == "Administrator")
            {
                var adminUsers = userManger.Users.ToList()
                    .Where(u => userManger.IsInRole(u.Id, "Administrator"))
                    .ToList().Count();
                if (adminUsers < 2)
                {
                    ViewBag.Error = "Cannot remove last administrator";
                    return RedirectToAction("Details", "Admin", new { id = user.Id });
                }
            }
            userManger.RemoveFromRole(id, role);

            if (user.UserID != null)
            {
                try
                {
                    var usrMrg = new LogicLayer.Usermanager();
                    usrMrg.DeleteFromRole((int)user.UserID, role);
                }
                catch (Exception)
                {
                    // nothing to do
                }
            }
            return RedirectToAction("Details", "Admin", new { id = user.Id });
        }

        public ActionResult AddRole(string id, string role)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManager.Users.First(u => u.Id == id);

            userManager.AddToRole(id, role);

            if (user.UserID != null)
            {
                try
                {
                    var usrMrg = new LogicLayer.Usermanager();
                    usrMrg.CreateUserRole((int)user.UserID, role);
                }
                catch (Exception)
                {
                    // nothing to do
                }
            }
            return RedirectToAction("Details", "Admin", new { id = user.Id });
        }
    }
}
