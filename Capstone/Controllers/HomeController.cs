using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using Microsoft.AspNet.Identity;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        //return View(await db.Tournaments.Where(a => a.OrganizerId == id).ToListAsync());
        //public ActionResult Index()
        //{
        //    if (User.Identity.IsAuthenticated == true)
        //    {
        //        return View("IndexSignedIn");
        //    }
        //    return View();
        //}

        private TournamentManagerContext db = new TournamentManagerContext();
        public async Task<ActionResult> Index()
        {
            var id = User.Identity.GetUserId();
            
            return View(await db.Tournaments.ToListAsync());

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            if (User.Identity.IsAuthenticated == true)
            {
                return View("AboutSignedIn");
            }

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            if (User.Identity.IsAuthenticated == true)
            {
                return View("ContactSignedIn");
            }

            return View();
        }
    }
}